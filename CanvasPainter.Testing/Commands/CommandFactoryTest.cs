using CanvasPainter.Exceptions;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Commands
{
    public class CommandFactoryTest
    {
        [Fact]
        public void CreateFor_TypeCWithValidInputParameters_ReturnsCreateCommand()
        {
            // arrange
            var inputParameters = new string("C 20 4");

            // act
            var createCommand = MessageFactory.CreateFor(inputParameters);

            // assert
            Assert.Equal(typeof(CreateMessage), createCommand.GetType());
        }

        [Fact]
        public void CreateFor_TypeCWithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new string("C 20 X");

            // act & assert
            Assert.Throws<ValidationException>(() => MessageFactory.CreateFor(inputParameters));
        }

        [Fact]
        public void CreateFor_TypeCWithInvalidSize_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new string("C 50 100");

            // act & assert
            Assert.Throws<ValidationException>(() => MessageFactory.CreateFor(inputParameters));
        }

        [Fact]
        public void CreateFor_TypeQWithValidParameters_ReturnsQuitCommand()
        {
            // arrange
            var inputParameters = new string("Q");

            // act
            var quitCommand = MessageFactory.CreateFor(inputParameters);

            // assert
            Assert.Equal(typeof(QuitMessage), quitCommand.GetType());
        }

        [Fact]
        public void CreateFor_TypeQWithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new string("Q 100");

            // act & assert
            Assert.Throws<ValidationException>(() => MessageFactory.CreateFor(inputParameters));
        }

        [Fact]
        public void CreateFor_TypeLWithValidParameters_ReturnsLineCommand()
        {
            // arrange
            var inputParameters = new string("L 1 2 6 2");

            // act
            var lineCommand = MessageFactory.CreateFor(inputParameters);

            // assert
            Assert.Equal(typeof(LineMessage), lineCommand.GetType());
        }

        [Fact]
        public void CreateFor_TypeLWithInvalidParameters_ThrowsCommandException()
        {
            // arrange
            var inputParameters = new string("X 1 2 6 2");

            // act & assert
            Assert.Throws<CommandException>(() => MessageFactory.CreateFor(inputParameters));
        }

        [Fact]
        public void CreateFor_TypeLWithNotStraightParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new string("L 1 2 6 3");

            // act & assert
            Assert.Throws<ValidationException>(() => MessageFactory.CreateFor(inputParameters));
        }

        [Fact]
        public void CreateFor_TypeRWithValidParameters_ReturnsRectangleCommand()
        {
            // arrange
            var inputParameters = new string("R 14 1 18 3");

            // act
            var rectangleCommand = MessageFactory.CreateFor(inputParameters);

            // assert
            Assert.Equal(typeof(RectangleMessage), rectangleCommand.GetType());
        }

        [Fact]
        public void CreateFor_TypeRWithValidParameters_ReturnsFloodFillCommand()
        {
            // arrange
            var inputParameters = new string("B 20 4 o");

            // act
            var floodFillCommand = MessageFactory.CreateFor(inputParameters);

            // assert
            Assert.Equal(typeof(FloodFillMessage), floodFillCommand.GetType());
        }
    }
}