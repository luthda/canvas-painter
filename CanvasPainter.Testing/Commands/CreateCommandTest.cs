using CanvasPainter.Commands;
using CanvasPainter.Exceptions;
using Xunit;

namespace CanvasPainter.Testing.Commands
{
    public class CreateCommandTest
    {
        private CreateCommand CreateCommand { get; set; }

        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            
            // act
            CreateCommand = new CreateCommand(inputParameters);
            
            // assert
            Assert.Equal(20, CreateCommand.Width);
            Assert.Equal(4, CreateCommand.Height);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[]{"C", "20", "X"};
            
            // act & assert
            Assert.Throws<ValidationException>(() => CreateCommand = new CreateCommand(inputParameters));
        }
        
        [Fact]
        public void ValidateAndSetProperties_WithInvalidSize_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[]{"C", "0", "200"};
            
            // act & assert
            Assert.Throws<ValidationException>(() => CreateCommand = new CreateCommand(inputParameters));
        }
    }
}