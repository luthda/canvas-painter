using System;
using CanvasPainter.Commands;
using Xunit;

namespace CanvasPainter.Testing.Commands
{
    public class QuitCommandTest
    {
        private QuitCommand QuitCommand { get; set; }
        
        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsQuitProp()
        {
            // arrange
            var inputParameters = new string[] {"Q"};
            
            // act
            QuitCommand = new QuitCommand(inputParameters);
            
            // assert
            Assert.True(QuitCommand.IsQuit);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string[] {"X", "5"};

            // act & assert
            Assert.Throws<ArgumentException>(() => QuitCommand = new QuitCommand(inputParameters));
        }
    }
}