using CanvasPainter.Exceptions;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Messages
{
    public class FloodFillMessageTest
    {
        private FloodFillMessage FloodFillMessage { get; set; }

        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new[] {"B", "10", "3", "o"};

            // act
            FloodFillMessage = new FloodFillMessage(inputParameters);

            // assert
            Assert.Equal(10, FloodFillMessage.ColorPoint.X);
            Assert.Equal(3, FloodFillMessage.ColorPoint.Y);
            Assert.Equal('o', FloodFillMessage.FillColor);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"B", "10", "2", "630"};

            // act & assert
            Assert.Throws<CanvasException>(() => FloodFillMessage = new FloodFillMessage(inputParameters));
        }

        [Fact]
        public void ValidateAndSetProperties_WithTooShortParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"B", "10", "2"};

            // act & assert
            Assert.Throws<CanvasException>(() => FloodFillMessage = new FloodFillMessage(inputParameters));
        }
    }
}