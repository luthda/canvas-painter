using CanvasPainter.Exceptions;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Messages
{
    public class RectangleMessageTest
    {
        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new[] {"R", "14", "1", "18", "3"};

            // act
            var rectangleMessage = new RectangleMessage(inputParameters);

            // assert
            Assert.Equal(14, rectangleMessage.StartPoint.X);
            Assert.Equal(18, rectangleMessage.EndPoint.X);
            Assert.Equal(1, rectangleMessage.StartPoint.Y);
            Assert.Equal(3, rectangleMessage.EndPoint.Y);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"R", "1", "2", "6"};

            // act & assert
            Assert.Throws<CanvasException>(() => new RectangleMessage(inputParameters));
        }
    }
}