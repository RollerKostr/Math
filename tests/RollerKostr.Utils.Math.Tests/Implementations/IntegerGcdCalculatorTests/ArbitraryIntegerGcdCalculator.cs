using FluentAssertions;
using RollerKostr.Utils.Math.Implementations;
using Xunit;

namespace RollerKostr.Utils.Math.Tests.Implementations.IntegerGcdCalculatorTests
{
    public class ArbitraryIntegerGcdCalculator
    {
        // TODO[mk] add test for exceptions
        
        [Theory]
        [InlineData(0,  0,  0,  0)]
        [InlineData(1,  0,  0,  1)]
        [InlineData(1,  0,  1,  0)]
        [InlineData(1,  0,  1,  1)]
        [InlineData(1,  1,  0,  2)]
        [InlineData(1,  2,  3,  3)]
        [InlineData(1,  3,  5,  5)]
        [InlineData(2,  2,  4,  4)]
        [InlineData(6,  6, 12, 12)]
        [InlineData(6, 12, 30, 30)]
        public void Gcd_ShouldReturnCorrectGcd(int expectedGcd, params int[] arguments)
        {
            // Arrange
            
            // Act
            var gcd = IntegerGcdCalculator.Gcd(arguments);

            // Assert
            gcd.Should().Be(expectedGcd);
        }
        
        // TODO[mk] add test for associativity
    }
}