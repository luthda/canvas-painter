using CanvasPainter.Exceptions;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Messages
{
    public class QuitMessageTest
    {
        private QuitMessage QuitMessage { get; set; }

        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsQuitProp()
        {
            // arrange
            var inputParameters = new[] {"Q"};

            // act
            QuitMessage = new QuitMessage(inputParameters);

            // assert
            Assert.Equal(typeof(QuitMessage), QuitMessage.GetType());
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"X", "5"};

            // act & assert
            Assert.Throws<CanvasException>(() => QuitMessage = new QuitMessage(inputParameters));
        }
    }
}