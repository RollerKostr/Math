using System;
using System.Linq;

namespace RollerKostr.Utils.Math
{
    public static class GcdCalculator
    {
        public static int Gcd(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentException(
                    "Both arguments must be non-negative.");
            }
            
            return b != 0
                ? Gcd(b, a % b)
                : a;
        }
        
        public static int Gcd(params int[] arguments)
        {
            switch (arguments.Length)
            {
                case 0:
                    throw new ArgumentException(
                        $"Function {nameof(Gcd)}() requires at least 1 argument.");
                case 1:
                    return arguments[0];
                default:
                    return arguments.Aggregate(Gcd);
            }
        }
        
        public static double Agcd(double tolerancePercent, params double[] arguments)
        {
            return 0d;
        }
    }
}