using CanvasPainter.Exceptions;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Messages
{
    public class RectangleMessageTest
    {
        private RectangleMessage RectangleMessage { get; set; }

        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new[] {"R", "14", "1", "18", "3"};

            // act
            RectangleMessage = new RectangleMessage(inputParameters);

            // assert
            Assert.Equal(14, RectangleMessage.StartPoint.X);
            Assert.Equal(18, RectangleMessage.EndPoint.X);
            Assert.Equal(1, RectangleMessage.StartPoint.Y);
            Assert.Equal(3, RectangleMessage.EndPoint.Y);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"R", "1", "2", "6"};

            // act & assert
            Assert.Throws<CanvasException>(() => RectangleMessage = new RectangleMessage(inputParameters));
        }
    }
}