using CanvasPainter.Exceptions;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Messages
{
    public class CreateMessageTest
    {
        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};

            // act
            var createMessage = new CreateMessage(inputParameters);

            // assert
            Assert.Equal(20, createMessage.Width);
            Assert.Equal(4, createMessage.Height);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "X"};

            // act & assert
            Assert.Throws<CanvasException>(() => new CreateMessage(inputParameters));
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidSize_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"C", "0", "200"};

            // act & assert
            Assert.Throws<CanvasException>(() => new CreateMessage(inputParameters));
        }
    }
}