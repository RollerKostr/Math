using System.Linq;
using FluentAssertions;
using RollerKostr.Utils.Math.Implementations;
using Xunit;

namespace RollerKostr.Utils.Math.Tests.Implementations.ApproximateGcdCalculatorTests
{
    public class ArbitraryApproximateGcdCalculatorTests
    {
        private const decimal FloatingPointTolerance = 0.000001m;
        
        // TODO[mk] add test for exceptions
        
        [Theory]
        [InlineData(0, 2.222, 2.222, 6.666, 8.888)]
        [InlineData(0, 3.333, 6.666, 9.999, 13.332)]
        public void Agcd_ShouldReturnAgcdWithinTolerance(decimal allowedGcdTolerancePercent,
            decimal expectedAgcd, params double[] arguments)
        {
            // Arrange
            var args = arguments.Select(d => (decimal) d).ToArray();
            
            // Act
            var agcd = ApproximateGcdCalculator.Agcd(allowedGcdTolerancePercent, args);

            // Assert
            agcd.Should().BeApproximately(expectedAgcd, FloatingPointTolerance);
        }
        
        // TODO[mk] add test for associativity
    }
}