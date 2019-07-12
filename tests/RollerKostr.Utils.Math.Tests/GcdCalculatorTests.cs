using FluentAssertions;
using Xunit;

namespace RollerKostr.Utils.Math.Tests
{
    public class GcdCalculatorTests
    {
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
        public void Gcd_ShouldReturnGcd(int a, int b, int expectedGcd)
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
        public void Gcd_ShouldReturnDivisorWithoutReminder(int a, int b)
        {
            // Arrange

            // Act
            var gcd = GcdCalculator.Gcd(a, b);

            // Assert
            (a % gcd).Should().Be(0);
            (b % gcd).Should().Be(0);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        public void Gcd_ShouldReturnGreatestDivisor(int a, int b)
        {
            // Arrange
            
            // Act
            var gcd = GcdCalculator.Gcd(a, b);

            // Assert
            // TODO[mk] add check for greatest divisor
        }
        
        [Fact]
        public void Agcd_ShouldReturnAgcd()
        {
            // Arrange
            
            // Act
            
            // Assert
        }
    }
}