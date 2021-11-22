using CanvasPainter.Commands;
using CanvasPainter.Exceptions;
using Xunit;

namespace CanvasPainter.Testing.Commands
{
    public class UndoCommandTest
    {
        private UndoCommand UndoCommand { get; set; }

        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsUndoProperty()
        {
            // arrange
            var inputParameters = new[] {"Z"};

            // act
            var undoCommand = new UndoCommand(inputParameters);

            // assert
            Assert.Equal(typeof(UndoCommand), undoCommand.GetType());
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsCommandException()
        {
            // arrange
            var inputParameters = new[] {"Z", "10"};

            // act & assert
            Assert.Throws<CommandException>(() => UndoCommand = new UndoCommand(inputParameters));
        }
    }
}