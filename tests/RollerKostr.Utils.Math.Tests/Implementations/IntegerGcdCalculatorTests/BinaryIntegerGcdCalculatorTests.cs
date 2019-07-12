using System;
using FluentAssertions;
using RollerKostr.Utils.Math.Implementations;
using Xunit;

namespace RollerKostr.Utils.Math.Tests.Implementations.IntegerGcdCalculatorTests
{
    public class BinaryIntegerGcdCalculatorTests
    {
        [Theory]
        [InlineData(-1,  0)]
        [InlineData(-1,  1)]
        [InlineData(-1, -1)]
        public void Gcd_IfAnyArgumentIsNegative_ShouldThrowArgumentException(int a, int b)
        {
            // Arrange

            // Act
            Action action = () => _ = IntegerGcdCalculator.Gcd(a, b);

            // Assert
            action.Should().Throw<ArgumentException>();
        }
        
        [Theory]
        [InlineData( 0,  0, 0)]
        [InlineData( 0,  1, 1)]
        [InlineData( 1,  1, 1)]
        [InlineData( 1,  2, 1)]
        [InlineData( 2,  3, 1)]
        [InlineData( 3,  5, 1)]
        [InlineData( 2,  4, 2)]
        [InlineData( 6, 12, 6)]
        [InlineData(12, 30, 6)]
        public void Gcd_ShouldReturnCorrectGcd(int a, int b, int expectedGcd)
        {
            // Arrange
            
            // Act
            var gcd = IntegerGcdCalculator.Gcd(a, b);

            // Assert
            gcd.Should().Be(expectedGcd);
        }

        [Theory]
        [InlineData( 0,  1)]
        [InlineData( 1,  1)]
        [InlineData( 1,  2)]
        [InlineData( 2,  3)]
        [InlineData( 3,  5)]
        [InlineData( 2,  4)]
        [InlineData( 6, 12)]
        [InlineData(12, 30)]
        // TODO[mk] add random data generation + output logging
        public void Gcd_ShouldReturnValueWhichDivideWithoutRemainder(int a, int b)
        {
            // Arrange

            // Act
            var gcd = IntegerGcdCalculator.Gcd(a, b);

            // Assert
            var remainderA = a % gcd; 
            var remainderB = b % gcd; 
            remainderA.Should().Be(0);
            remainderB.Should().Be(0);
        }

        [Theory]
        [InlineData( 0,  1)]
        [InlineData( 1,  1)]
        [InlineData( 1,  2)]
        [InlineData( 2,  3)]
        [InlineData( 3,  5)]
        [InlineData( 2,  4)]
        [InlineData( 6, 12)]
        [InlineData(12, 30)]
        // TODO[mk] add random data generation + output logging
        public void Gcd_ShouldReturnValueWhichDivideToCoprimeQuotients(int a, int b)
        {
            // Arrange
            
            // Act
            var gcd = IntegerGcdCalculator.Gcd(a, b);

            // Assert
            var quotientA = a / gcd;
            var quotientB = b / gcd;
            var quotientsGcd = IntegerGcdCalculator.Gcd(quotientA, quotientB);
            quotientsGcd.Should().Be(1);
        }
        
        [Theory]
        [InlineData( 0,  1)]
        [InlineData( 1,  2)]
        [InlineData( 2,  3)]
        [InlineData( 3,  5)]
        [InlineData( 6, 12)]
        [InlineData(12, 30)]
        // TODO[mk] add random data generation + output logging
        public void Gcd_ShouldBeCommutative(int a, int b)
        {
            // Arrange
            
            // Act
            var gcdDirect = IntegerGcdCalculator.Gcd(a, b);
            var gcdInverse = IntegerGcdCalculator.Gcd(b, a);

            // Assert
            gcdDirect.Should().Be(gcdInverse);
        }
    }
}