using System;
using CanvasPainter.Commands;
using Xunit;

namespace CanvasPainter.Testing.Commands
{
    public class CommandFactoryTest
    {
        private CommandFactory CommandFactory { get; set; }

        public CommandFactoryTest()
        {
            CommandFactory = new CommandFactory();
        }
        
        [Fact]
        public void CreateCommandFor_TypeCWithValidInputParameters_ReturnsCreateCommand()
        {
            // arrange
            var inputParameters = new string("C 20 4");
            
            // act
            var createCommand = CommandFactory.CreateCommandFor(inputParameters);
            
            // assert
            Assert.Equal(typeof(CreateCommand), createCommand.GetType());
        }

        [Fact]
        public void CreateCommandFor_TypeCWithInvalidParameters_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string("C 20 X");
            
            // act & assert
            Assert.Throws<ArgumentException>(() => CommandFactory.CreateCommandFor(inputParameters));
        }
        
        [Fact]
        public void CreateCommandFor_TypeCWithInvalidSize_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string("C 50 100");
            
            // act & assert
            Assert.Throws<ArgumentException>(() => CommandFactory.CreateCommandFor(inputParameters));
        }

        [Fact]
        public void CreateCommandFor_TypeQWithValidParameters_ReturnsQuitCommand()
        {
            // arrange
            var inputParameters = new string("Q");
            
            // act
            var quitCommand = CommandFactory.CreateCommandFor(inputParameters);
            
            // assert
            Assert.Equal(typeof(QuitCommand), quitCommand.GetType());
        }
        
        [Fact]
        public void CreateCommandFor_TypeQ_WithInvalidParameters_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string("Q 100");
            
            // act & assert
            Assert.Throws<ArgumentException>(() => CommandFactory.CreateCommandFor(inputParameters));
        }
    }
}