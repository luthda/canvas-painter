using CanvasPainter.Exceptions;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Messages
{
    public class QuitMessageTest
    {
        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsQuitProp()
        {
            // arrange
            var inputParameters = new[] {"Q"};

            // act
            var quitMessage = new QuitMessage(inputParameters);

            // assert
            Assert.Equal(typeof(QuitMessage), quitMessage.GetType());
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"X", "5"};

            // act & assert
            Assert.Throws<CanvasException>(() => new QuitMessage(inputParameters));
        }
    }
}