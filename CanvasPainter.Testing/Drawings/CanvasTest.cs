using System;
using System.Text;
using CanvasPainter.Commands;
using CanvasPainter.Drawings;
using Xunit;

namespace CanvasPainter.Testing.Drawings
{
    public class CanvasTest
    {
        private Canvas Canvas { get; set; } = new EmptyCanvas();

        [Fact]
        public void Initialize_WithValidParameters_CreatesCanvas()
        {
            // arrange
            var inputParameters = new string[] {"C", "10", "9"};

            // act
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));

            // assert
            Assert.Equal(10, Canvas.Width);
            Assert.Equal(9, Canvas.Height);
            Assert.Equal(90, Canvas.CanvasBody.Length);
        }

        [Fact]
        public void AddBorder_ReturnsCanvasWithBorderAsString()
        {
            // arrange
            var inputParameters = new string[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|    |");
            expectedString.AppendLine("|    |");
            expectedString.AppendLine("------");

            // act
            var actualCanvasString = Canvas.DrawBorder();

            // assert
            Assert.Equal(expectedString.ToString(), actualCanvasString);
        }

        [Fact]
        public void HandleEmptyCanvas_WithInvalidParameters_ThrowsArgumentException()
        {
            // arrange
            Canvas = new EmptyCanvas();
            var inputParameters = new string[] {"C", "4", "2"};
            var command = new CreateCommand(inputParameters);

            // act & assert
            Assert.ThrowsAny<ArgumentException>(() => Canvas.Draw(command));
        }

        [Fact]
        public void DrawHorizontal_WithValidLineCommand_ReturnsDrawnCanvas()
        {
            // arrange
            var inputParameters = new string[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));
            var inputLineParameters = new string[] {"L", "1", "1", "4", "1"};
            var lineCommand = new LineCommand(inputLineParameters);

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|xxxx|");
            expectedString.AppendLine("|    |");
            expectedString.AppendLine("------");

            // act
            var actualCanvasString = Canvas.Draw(lineCommand);

            // assert
            Assert.Equal(expectedString.ToString(), actualCanvasString);
        }

        [Fact]
        public void DrawVertical_WithValidLineCommand_ReturnsDrawnCanvas()
        {
            // arrange
            var inputParameters = new string[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));
            var inputLineParameters = new string[] {"L", "1", "1", "1", "2"};
            var lineCommand = new LineCommand(inputLineParameters);

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|x   |");
            expectedString.AppendLine("|x   |");
            expectedString.AppendLine("------");

            // act
            var actualCanvasString = Canvas.Draw(lineCommand);
            
            // assert
            Assert.Equal(expectedString.ToString(), actualCanvasString);
        }
        
        [Fact]
        public void DrawHorizontalReverse_WithValidLineCommand_ReturnsDrawnCanvas()
        {
            // arrange
            var inputParameters = new string[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));
            var inputLineParameters = new string[] {"L", "4", "1", "1", "1"};
            var lineCommand = new LineCommand(inputLineParameters);

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|xxxx|");
            expectedString.AppendLine("|    |");
            expectedString.AppendLine("------");

            // act
            var actualCanvasString = Canvas.Draw(lineCommand);

            // assert
            Assert.Equal(expectedString.ToString(), actualCanvasString);
        }
        
        [Fact]
        public void DrawVerticalReverse_WithValidLineCommand_ReturnsDrawnCanvas()
        {
            // arrange
            var inputParameters = new string[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));
            var inputLineParameters = new string[] {"L", "1", "2", "1", "1"};
            var lineCommand = new LineCommand(inputLineParameters);

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|x   |");
            expectedString.AppendLine("|x   |");
            expectedString.AppendLine("------");

            // act
            var actualCanvasString = Canvas.Draw(lineCommand);
            
            // assert
            Assert.Equal(expectedString.ToString(), actualCanvasString);
        }
    }
}