using System;
using FluentAssertions;
using Xunit;

namespace RollerKostr.Utils.Math.Tests.GcdCalculatorTests
{
    public class BinaryGcdTests
    {
        [Theory]
        [InlineData(-1,  0)]
        [InlineData( 0, -1)]
        [InlineData( 1, -1)]
        [InlineData(-1,  1)]
        [InlineData(-1, -1)]
        public void Gcd_IfAnyArgumentIsNegative_ShouldThrowArgumentException(int a, int b)
        {
            // Arrange

            // Act
            Action action = () => _ = GcdCalculator.Gcd(a, b);

            // Assert
            action.Should().Throw<ArgumentException>();
        }
        
        [Theory]
        [InlineData( 0,  0, 0)]
        [InlineData( 0,  1, 1)]
        [InlineData( 1,  0, 1)]
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
            var gcd = GcdCalculator.Gcd(a, b);

            // Assert
            gcd.Should().Be(expectedGcd);
        }

        [Theory]
        [InlineData( 0,  1)]
        [InlineData( 1,  0)]
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
            var gcd = GcdCalculator.Gcd(a, b);

            // Assert
            var remainderA = a % gcd; 
            var remainderB = b % gcd; 
            remainderA.Should().Be(0);
            remainderB.Should().Be(0);
        }

        [Theory]
        [InlineData( 0,  1)]
        [InlineData( 1,  0)]
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
            var gcd = GcdCalculator.Gcd(a, b);

            // Assert
            var quotientA = a / gcd;
            var quotientB = b / gcd;
            var quotientsGcd = GcdCalculator.Gcd(quotientA, quotientB);
            quotientsGcd.Should().Be(1);
        }
    }
}