using System;
using System.Text;
using CanvasPainter.Commands;
using CanvasPainter.Drawings;
using CanvasPainter.Exceptions;
using Xunit;

namespace CanvasPainter.Testing.Drawings
{
    public class CanvasTest
    {
        private Canvas Canvas { get; set; } = new EmptyCanvas();

        [Fact]
        public void Initialize_WithValidParameters_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "10", "9"};

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
            var inputParameters = new[] {"C", "4", "2"};
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
        public void HandleEmptyCanvas_WithInvalidParameters_ThrowsCommandException()
        {
            // arrange
            Canvas = new EmptyCanvas();
            var inputParameters = new[] {"C", "4", "2"};
            var command = new CreateCommand(inputParameters);

            // act & assert
            Assert.ThrowsAny<CommandException>(() => Canvas.Draw(command));
        }

        [Fact]
        public void DrawHorizontal_WithValidLineCommand_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));

            var inputLineParameters = new[] {"L", "1", "1", "4", "1"};
            var lineCommand = new LineCommand(inputLineParameters);

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|xxxx|");
            expectedString.AppendLine("|    |");
            expectedString.AppendLine("------");

            // act
            Canvas = Canvas.Draw(lineCommand);

            // assert
            Assert.Equal(expectedString.ToString(), Canvas.DrawBorder());
        }

        [Fact]
        public void DrawVertical_WithValidLineCommand_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));

            var inputLineParameters = new[] {"L", "1", "1", "1", "2"};
            var lineCommand = new LineCommand(inputLineParameters);

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|x   |");
            expectedString.AppendLine("|x   |");
            expectedString.AppendLine("------");

            // act
            Canvas = Canvas.Draw(lineCommand);

            // assert
            Assert.Equal(expectedString.ToString(), Canvas.DrawBorder());
        }

        [Fact]
        public void DrawHorizontalReverse_WithValidLineCommand_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));

            var inputLineParameters = new[] {"L", "4", "1", "1", "1"};
            var lineCommand = new LineCommand(inputLineParameters);

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|xxxx|");
            expectedString.AppendLine("|    |");
            expectedString.AppendLine("------");

            // act
            Canvas = Canvas.Draw(lineCommand);

            // assert
            Assert.Equal(expectedString.ToString(), Canvas.DrawBorder());
        }

        [Fact]
        public void DrawVerticalReverse_WithValidLineCommand_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));

            var inputLineParameters = new[] {"L", "1", "2", "1", "1"};
            var lineCommand = new LineCommand(inputLineParameters);

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|x   |");
            expectedString.AppendLine("|x   |");
            expectedString.AppendLine("------");

            // act
            Canvas = Canvas.Draw(lineCommand);

            // assert
            Assert.Equal(expectedString.ToString(), Canvas.DrawBorder());
        }

        [Fact]
        public void DrawRectangle_WithValidRectangleCommand_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));

            var rectangleParameters = new[] {"R", "14", "1", "18", "3"};
            var rectangleCommand = new RectangleCommand(rectangleParameters);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("----------------------");
            stringBuilder.AppendLine("|             xxxxx  |");
            stringBuilder.AppendLine("|             x   x  |");
            stringBuilder.AppendLine("|             xxxxx  |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("----------------------");

            // act
            Canvas = Canvas.Draw(rectangleCommand);

            // assert
            Assert.Equal(stringBuilder.ToString(), Canvas.DrawBorder());
        }

        [Fact]
        public void DrawRectangle_WithInvalidRectangleCommand_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));
            var inputRectangleParameters = new[] {"R", "30", "1", "18", "3"};
            var rectangleCommand = new RectangleCommand(inputRectangleParameters);

            // act & assert
            Assert.Throws<ArgumentException>(() => Canvas.Draw(rectangleCommand));
        }

        [Fact]
        public void DrawFloodFill_WithValidFloodFillCommand_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));
            var inputFloodFillParameters = new[] {"B", "20", "4", "o"};
            var floodFillCommand = new FloodFillCommand(inputFloodFillParameters);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("----------------------");
            stringBuilder.AppendLine("|oooooooooooooooooooo|");
            stringBuilder.AppendLine("|oooooooooooooooooooo|");
            stringBuilder.AppendLine("|oooooooooooooooooooo|");
            stringBuilder.AppendLine("|oooooooooooooooooooo|");
            stringBuilder.AppendLine("----------------------");

            // act
            Canvas = Canvas.Draw(floodFillCommand);

            // assert
            Assert.Equal(stringBuilder.ToString(), Canvas.DrawBorder());
        }

        [Fact]
        public void DrawFloodFill_WithInvalidFloodFillCommand_DoesNothing()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));
            var inputFloodFillParameters = new[] {"B", "20", "5", "o"};
            var floodFillCommand = new FloodFillCommand(inputFloodFillParameters);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("----------------------");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("----------------------");

            // act
            Canvas = Canvas.Draw(floodFillCommand);

            // assert
            Assert.Equal(stringBuilder.ToString(), Canvas.DrawBorder());
        }

        [Fact]
        public void Clone_ReturnsNewCanvasObject()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            Canvas = Canvas.CreateFor(new CreateCommand(inputParameters));
            
            // act
            var clonedCanvas = Canvas.Clone();
            
            // assert
            Assert.NotEqual(Canvas, clonedCanvas);
            Assert.Equal(Canvas.Height, clonedCanvas.Height);
            Assert.Equal(Canvas.Width, clonedCanvas.Width);
        } 
    }
}