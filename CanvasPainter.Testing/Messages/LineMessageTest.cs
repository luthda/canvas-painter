using CanvasPainter.Exceptions;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Messages
{
    public class LineMessageTest
    {
        private LineMessage LineMessage { get; set; }

        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new[] {"L", "1", "2", "6", "2"};

            // act
            LineMessage = new LineMessage(inputParameters);

            // assert
            Assert.Equal(1, LineMessage.StartPoint.X);
            Assert.Equal(6, LineMessage.EndPoint.X);
            Assert.Equal(2, LineMessage.StartPoint.Y);
            Assert.Equal(2, LineMessage.EndPoint.Y);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"L", "1", "2", "6", "4"};

            // act & assert
            Assert.Throws<CanvasException>(() => LineMessage = new LineMessage(inputParameters));
        }

        [Fact]
        public void ValidateAndSetProperties_WithTooShortParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"L", "1", "2", "6"};

            // act & assert
            Assert.Throws<CanvasException>(() => LineMessage = new LineMessage(inputParameters));
        }
    }
}