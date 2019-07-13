using FluentAssertions;
using RollerKostr.Utils.Math.Implementations;
using Xunit;

namespace RollerKostr.Utils.Math.Tests.Implementations.ApproximateGcdCalculatorTests
{
    public class BinaryApproximateGcdCalculatorTests
    {
        private const decimal FloatingPointTolerance = 0.000001m;
        
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
        public void Agcd_IfZeroGcdTolerance_ShouldReturnGcd(decimal a, decimal b, decimal expectedAgcd)
        {
            // Arrange
            const decimal gcdTolerancePercent = 0m;
            
            // Act
            var agcd = ApproximateGcdCalculator.Agcd(gcdTolerancePercent, a, b);

            // Assert
            agcd.Should().BeApproximately(expectedAgcd, FloatingPointTolerance);
        }
        
        [Theory]
        [InlineData(1.111, 2.222, 1.111)]
        [InlineData(2.222, 3.333, 1.111)]
        public void Agcd_ShouldReturnCorrectAgcd(decimal a, decimal b, decimal expectedAgcd)
        {
            // Arrange
            const decimal gcdTolerancePercent = 0m;
            
            // Act
            var agcd = ApproximateGcdCalculator.Agcd(gcdTolerancePercent, a, b);

            // Assert
            agcd.Should().BeApproximately(expectedAgcd, FloatingPointTolerance);
        }
        
        [Theory]
        [InlineData(1.110, 2.223, 1.110, 1)]
        [InlineData(2.221, 3.334, 1.108, 1)]
        public void Agcd_ShouldReturnAgcdWithinTolerance(decimal a, decimal b, decimal expectedAgcd,
            decimal allowedGcdTolerancePercent)
        {
            // Arrange
            
            // Act
            var agcd = ApproximateGcdCalculator.Agcd(allowedGcdTolerancePercent, a, b);

            // Assert
            agcd.Should().BeApproximately(expectedAgcd, FloatingPointTolerance);
        }
        
        [Theory]
        [InlineData(1.110, 2.223, 1)]
        [InlineData(2.221, 3.334, 1)]
        // TODO[mk] generate random data
        public void Agcd_ShouldReturnValueWhichDivideWithAllowedRemainder(decimal a, decimal b,
            decimal allowedGcdTolerancePercent)
        {
            // Arrange
            
            // Act
            var agcd = ApproximateGcdCalculator.Agcd(allowedGcdTolerancePercent, a, b);

            // Assert
            var allowedRemainderA = a * allowedGcdTolerancePercent / 100m;
            var allowedRemainderB = b * allowedGcdTolerancePercent / 100m;
            var remainderA = a % agcd;
            var remainderB = b % agcd;
            remainderA.Should().BeLessOrEqualTo(allowedRemainderA);
            remainderB.Should().BeLessOrEqualTo(allowedRemainderB);
        }
    }
}