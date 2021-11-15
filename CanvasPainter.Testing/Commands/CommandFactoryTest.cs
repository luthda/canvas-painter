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
        public void CreateFor_TypeCWithValidInputParameters_ReturnsCreateCommand()
        {
            // arrange
            var inputParameters = new string("C 20 4");
            
            // act
            var createCommand = CommandFactory.CreateFor(inputParameters);
            
            // assert
            Assert.Equal(typeof(CreateCommand), createCommand.GetType());
        }

        [Fact]
        public void CreateFor_TypeCWithInvalidParameters_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string("C 20 X");
            
            // act & assert
            Assert.Throws<ArgumentException>(() => CommandFactory.CreateFor(inputParameters));
        }
        
        [Fact]
        public void CreateFor_TypeCWithInvalidSize_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string("C 50 100");
            
            // act & assert
            Assert.Throws<ArgumentException>(() => CommandFactory.CreateFor(inputParameters));
        }

        [Fact]
        public void CreateFor_TypeQWithValidParameters_ReturnsQuitCommand()
        {
            // arrange
            var inputParameters = new string("Q");
            
            // act
            var quitCommand = CommandFactory.CreateFor(inputParameters);
            
            // assert
            Assert.Equal(typeof(QuitCommand), quitCommand.GetType());
        }
        
        [Fact]
        public void CreateFor_TypeQWithInvalidParameters_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string("Q 100");
            
            // act & assert
            Assert.Throws<ArgumentException>(() => CommandFactory.CreateFor(inputParameters));
        }

        [Fact]
        public void CreateFor_TypeLWithValidParameters_ReturnsLineCommand()
        {
            // arrange
            var inputParameters = new string("L 1 2 6 2");
            
            // act
            var lineCommand = CommandFactory.CreateFor(inputParameters);
            
            // assert
            Assert.Equal(typeof(LineCommand), lineCommand.GetType());
        }

        [Fact]
        public void CreateFor_TypeLWithInvalidParameters_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string("X 1 2 6 2");
            
            // act & assert
            Assert.Throws<ArgumentException>(() => CommandFactory.CreateFor(inputParameters));
        }
        
        [Fact]
        public void CreateFor_TypeLWithNotStraightParameters_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string("L 1 2 6 3");
            
            // act & assert
            Assert.Throws<ArgumentException>(() => CommandFactory.CreateFor(inputParameters));
        }

        [Fact]
        public void CreateFor_TypeRWithValidParameters_ReturnsRectangleCommand()
        {
            // arrange
            var inputParameters = new string("R 14 1 18 3");
            
            // act
            var rectangleCommand = CommandFactory.CreateFor(inputParameters);
            
            // assert
            Assert.Equal(typeof(RectangleCommand), rectangleCommand.GetType());
        }
    }
}