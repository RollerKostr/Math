using System;

namespace RollerKostr.Utils.Math.Implementations
{
    internal static class ApproximateGcdCalculator
    {
        private const double FloatingPointTolerance = 0.000001d;
        
        public static double Agcd(double tolerancePercent, double a, double b)
        {
            if (tolerancePercent < 0)
            {
                throw new ArgumentException(
                    "Tolerance percent must be non-negative.");
            }

            if (tolerancePercent > 100)
            {
                throw new ArgumentException(
                    "Tolerance percent must be not greater than 100.");
            }
            
            if (a < 0 || b < 0)
            {
                throw new ArgumentException(
                    "Both arguments must be non-negative.");
            }

            // TODO[mk] add check gcdTolerance is not less than Floating point one 
            var gcdTolerance = System.Math.Min(a, b) * tolerancePercent / 100d;

            return AgcdWithAllowedRemainder(gcdTolerance, a, b);
        }

        private static double AgcdWithAllowedRemainder(double maxRemainder, double a, double b)
        {
            return !IsApproximatelyZero(b, maxRemainder)
                ? AgcdWithAllowedRemainder(maxRemainder,b, a % b)
                : a;
        }

        private static bool IsApproximatelyZero(double value, double tolerance)
        {
            return -tolerance <= value && value <= tolerance;
        }
    }
}