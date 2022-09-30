using CanvasPainter.Exceptions;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Messages
{
    public class FloodFillMessageTest
    {

        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new[] {"B", "10", "3", "o"};

            // act
            var floodFillMessage = new FloodFillMessage(inputParameters);

            // assert
            Assert.Equal(10, floodFillMessage.ColorPoint.X);
            Assert.Equal(3, floodFillMessage.ColorPoint.Y);
            Assert.Equal('o', floodFillMessage.FillColor);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"B", "10", "2", "630"};

            // act & assert
            Assert.Throws<CanvasException>(() => new FloodFillMessage(inputParameters));
        }

        [Fact]
        public void ValidateAndSetProperties_WithTooShortParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"B", "10", "2"};

            // act & assert
            Assert.Throws<CanvasException>(() => new FloodFillMessage(inputParameters));
        }
    }
}