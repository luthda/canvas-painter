using System.Text;
using CanvasPainter.Drawings;
using CanvasPainter.Exceptions;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Drawings
{
    public class CanvasTest
    {
        private Canvas Canvas { get; set; } = new EmptyCanvas();

        [Fact]
        public void InitializeAndAToString_ReturnsCanvasWithBorderAsString()
        {
            // arrange
            var inputParameters = new[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateMessage(inputParameters));

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|    |");
            expectedString.AppendLine("|    |");
            expectedString.AppendLine("------");

            // act
            var actualCanvasString = Canvas.ToString();

            // assert
            Assert.Equal(expectedString.ToString(), actualCanvasString);
        }

        [Fact]
        public void HandleEmptyCanvas_WithInvalidParameters_ThrowsCommandException()
        {
            // arrange
            Canvas = new EmptyCanvas();
            var inputParameters = new[] {"C", "4", "2"};
            var command = new CreateMessage(inputParameters);

            // act & assert
            Assert.ThrowsAny<CanvasException>(() => Canvas.Draw(command));
        }

        [Fact]
        public void DrawHorizontal_WithValidLineCommand_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateMessage(inputParameters));

            var inputLineParameters = new[] {"L", "1", "1", "4", "1"};
            var lineCommand = new LineMessage(inputLineParameters);

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|xxxx|");
            expectedString.AppendLine("|    |");
            expectedString.AppendLine("------");

            // act
            Canvas = Canvas.Draw(lineCommand);

            // assert
            Assert.Equal(expectedString.ToString(), Canvas.ToString());
        }

        [Fact]
        public void DrawVertical_WithValidLineCommand_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateMessage(inputParameters));

            var inputLineParameters = new[] {"L", "1", "1", "1", "2"};
            var lineCommand = new LineMessage(inputLineParameters);

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|x   |");
            expectedString.AppendLine("|x   |");
            expectedString.AppendLine("------");

            // act
            Canvas = Canvas.Draw(lineCommand);

            // assert
            Assert.Equal(expectedString.ToString(), Canvas.ToString());
        }

        [Fact]
        public void DrawHorizontalReverse_WithValidLineCommand_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateMessage(inputParameters));

            var inputLineParameters = new[] {"L", "4", "1", "1", "1"};
            var lineCommand = new LineMessage(inputLineParameters);

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|xxxx|");
            expectedString.AppendLine("|    |");
            expectedString.AppendLine("------");

            // act
            Canvas = Canvas.Draw(lineCommand);

            // assert
            Assert.Equal(expectedString.ToString(), Canvas.ToString());
        }

        [Fact]
        public void DrawVerticalReverse_WithValidLineCommand_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "4", "2"};
            Canvas = Canvas.CreateFor(new CreateMessage(inputParameters));

            var inputLineParameters = new[] {"L", "1", "2", "1", "1"};
            var lineCommand = new LineMessage(inputLineParameters);

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|x   |");
            expectedString.AppendLine("|x   |");
            expectedString.AppendLine("------");

            // act
            Canvas = Canvas.Draw(lineCommand);

            // assert
            Assert.Equal(expectedString.ToString(), Canvas.ToString());
        }

        [Fact]
        public void DrawRectangle_WithValidRectangleCommand_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            Canvas = Canvas.CreateFor(new CreateMessage(inputParameters));

            var rectangleParameters = new[] {"R", "14", "1", "18", "3"};
            var rectangleCommand = new RectangleMessage(rectangleParameters);

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
            Assert.Equal(stringBuilder.ToString(), Canvas.ToString());
        }

        [Fact]
        public void DrawRectangle_WithInvalidRectangleCommand_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            Canvas = Canvas.CreateFor(new CreateMessage(inputParameters));
            var inputRectangleParameters = new[] {"R", "30", "1", "18", "3"};
            var rectangleCommand = new RectangleMessage(inputRectangleParameters);

            // act & assert
            Assert.Throws<CanvasException>(() => Canvas.Draw(rectangleCommand));
        }

        [Fact]
        public void DrawFloodFill_WithValidFloodFillCommand_ReturnsCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            Canvas = Canvas.CreateFor(new CreateMessage(inputParameters));
            var inputFloodFillParameters = new[] {"B", "20", "4", "o"};
            var floodFillCommand = new FloodFillMessage(inputFloodFillParameters);

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
            Assert.Equal(stringBuilder.ToString(), Canvas.ToString());
        }

        [Fact]
        public void DrawFloodFill_WithInvalidFloodFillCommand_DoesNothing()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            Canvas = Canvas.CreateFor(new CreateMessage(inputParameters));
            var inputFloodFillParameters = new[] {"B", "20", "5", "o"};
            var floodFillCommand = new FloodFillMessage(inputFloodFillParameters);

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
            Assert.Equal(stringBuilder.ToString(), Canvas.ToString());
        }
    }
}