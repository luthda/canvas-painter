using CanvasPainter.Exceptions;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Messages
{
    public class LineMessageTest
    {
        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new[] {"L", "1", "2", "6", "2"};

            // act
            var lineMessage = new LineMessage(inputParameters);

            // assert
            Assert.Equal(1, lineMessage.StartPoint.X);
            Assert.Equal(6, lineMessage.EndPoint.X);
            Assert.Equal(2, lineMessage.StartPoint.Y);
            Assert.Equal(2, lineMessage.EndPoint.Y);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"L", "1", "2", "6", "4"};

            // act & assert
            Assert.Throws<CanvasException>(() => new LineMessage(inputParameters));
        }

        [Fact]
        public void ValidateAndSetProperties_WithTooShortParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"L", "1", "2", "6"};

            // act & assert
            Assert.Throws<CanvasException>(() => new LineMessage(inputParameters));
        }
    }
}