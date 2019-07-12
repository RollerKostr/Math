using System;
using RollerKostr.Utils.Math.Implementations;

// TODO[mk] change to RollerKostr.Math.GCD
namespace RollerKostr.Utils.Math
{
    public static class GcdCalculator
    {
        /// <summary>
        /// Calculates Greatest Common Divisor (GCD)
        /// of two non-negative integer numbers. 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public static int Gcd(int a, int b) =>
            IntegerGcdCalculator.Gcd(a, b);

        /// <summary>
        /// Calculates Greatest Common Divisor (GCD)
        /// of arbitrary number of non-negative integer numbers. 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public static int Gcd(params int[] arguments) =>
            IntegerGcdCalculator.Gcd(arguments);

        /// <summary>
        /// Calculates Approximate Greatest Common Divisor (AGCD)
        /// of two non-negative real numbers with specified tolerance.
        /// </summary>
        /// <param name="tolerancePercent">Allowed tolerance to find AGCD.</param>
        public static double Agcd(double tolerancePercent, double a, double b) =>
            ApproximateGcdCalculator.Agcd(tolerancePercent, a, b);
    }
}