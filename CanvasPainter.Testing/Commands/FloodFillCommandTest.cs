using CanvasPainter.Commands;
using CanvasPainter.Exceptions;
using Xunit;

namespace CanvasPainter.Testing.Commands
{
    public class FloodFillCommandTest
    {
        private FloodFillCommand FloodFillCommand { get; set; }

        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new[] {"B", "10", "3", "o"};

            // act
            FloodFillCommand = new FloodFillCommand(inputParameters);

            // assert
            Assert.Equal(10, FloodFillCommand.ColorPoint.X);
            Assert.Equal(3, FloodFillCommand.ColorPoint.Y);
            Assert.Equal('o', FloodFillCommand.FillColor);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"B", "10", "2", "630"};

            // act & assert
            Assert.Throws<ValidationException>(() => FloodFillCommand = new FloodFillCommand(inputParameters));
        }

        [Fact]
        public void ValidateAndSetProperties_WithTooShortParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"B", "10", "2"};

            // act & assert
            Assert.Throws<ValidationException>(() => FloodFillCommand = new FloodFillCommand(inputParameters));
        }
    }
}