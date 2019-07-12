using System;
using System.Linq;

namespace RollerKostr.Utils.Math
{
    public static class GcdCalculator
    {
        // TODO[mk] add another GCD algorithms support
        
        /// <summary>
        /// Calculates Greatest Common Divisor (GCD)
        /// of two non-negative integer numbers. 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
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
        
        /// <summary>
        /// Calculates Greatest Common Divisor (GCD)
        /// of arbitrary number of non-negative integer numbers. 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
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
        
        /// <summary>
        /// Calculates Approximate Greatest Common Divisor (AGCD)
        /// of two non-negative real numbers with specified tolerance.
        /// </summary>
        /// <param name="tolerancePercent">Allowed tolerance to find AGCD.</param>
        public static double Agcd(double tolerancePercent, double a, double b)
        {
            throw new NotImplementedException();
        }
    }
}