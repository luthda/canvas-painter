using System;
using CanvasPainter.Commands;
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
            var inputParameters = new string[]{"C", "20", "4"};
            
            // act
            CreateCommand = new CreateCommand(inputParameters);
            
            // assert
            Assert.Equal(20, CreateCommand.Width);
            Assert.Equal(4, CreateCommand.Height);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string[]{"C", "20", "X"};
            
            // act & assert
            Assert.Throws<ArgumentException>(() => CreateCommand = new CreateCommand(inputParameters));
        }
        
        [Fact]
        public void ValidateAndSetProperties_WithInvalidSize_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string[]{"C", "0", "200"};
            
            // act & assert
            Assert.Throws<ArgumentException>(() => CreateCommand = new CreateCommand(inputParameters));
        }
    }
}