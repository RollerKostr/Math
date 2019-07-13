using System;
using System.Linq;

namespace RollerKostr.Utils.Math.Implementations
{
    internal static class ApproximateGcdCalculator
    {
        private const decimal FloatingPointTolerance = 0.000001m;
        
        public static decimal Agcd(decimal tolerancePercent, params decimal[] arguments)
        {
            switch (arguments.Length)
            {
                case 0:
                    throw new ArgumentException(
                        $"Function {nameof(Agcd)}() requires at least 1 argument.");
                case 1:
                    return arguments[0];
                default:
                    var gcdTolerance = arguments.Min() * tolerancePercent / 100m;
                    return arguments.Aggregate((a, b) => AgcdWithAllowedRemainder(gcdTolerance, a, b));
            }
        }
        
        public static decimal Agcd(decimal tolerancePercent, decimal a, decimal b)
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
            var gcdTolerance = System.Math.Min(a, b) * tolerancePercent / 100m;

            return AgcdWithAllowedRemainder(gcdTolerance, a, b);
        }

        private static decimal AgcdWithAllowedRemainder(decimal maxRemainder, decimal a, decimal b)
        {
            return !IsApproximatelyZero(b, maxRemainder)
                ? AgcdWithAllowedRemainder(maxRemainder,b, a % b)
                : a;
        }

        private static bool IsApproximatelyZero(decimal value, decimal tolerance)
        {
            return -tolerance <= value && value <= tolerance;
        }
    }
}