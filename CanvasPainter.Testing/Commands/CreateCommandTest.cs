using CanvasPainter.Exceptions;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Commands
{
    public class CreateCommandTest
    {
        private CreateMessage CreateMessage { get; set; }

        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            
            // act
            CreateMessage = new CreateMessage(inputParameters);
            
            // assert
            Assert.Equal(20, CreateMessage.Width);
            Assert.Equal(4, CreateMessage.Height);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[]{"C", "20", "X"};
            
            // act & assert
            Assert.Throws<ValidationException>(() => CreateMessage = new CreateMessage(inputParameters));
        }
        
        [Fact]
        public void ValidateAndSetProperties_WithInvalidSize_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[]{"C", "0", "200"};
            
            // act & assert
            Assert.Throws<ValidationException>(() => CreateMessage = new CreateMessage(inputParameters));
        }
    }
}