using System;
using System.Text;
using CanvasPainter.Commands;
using CanvasPainter.Handlers;
using Xunit;

namespace CanvasPainter.Testing.Handlers
{
    public class PaintHandlerTest
    {
        private PaintHandler PaintHandler { get; set; }

        public PaintHandlerTest()
        {
            PaintHandler = new PaintHandler();
        }

        [Fact]
        public void HandleOn_CreateCommand_ReturnsDrawnCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            var createCommand = new CreateCommand(inputParameters);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("----------------------");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("----------------------");

            // act
            var actualCanvasString = PaintHandler.HandleOn(createCommand);

            // assert
            Assert.Equal(stringBuilder.ToString(), actualCanvasString);
        }

        [Fact]
        public void HandleOn_LineCommand_ReturnsDrawnCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            var createCommand = new CreateCommand(inputParameters);
            PaintHandler.HandleOn(createCommand);

            var inputLineParameters = new[] {"L", "1", "2", "6", "2"};
            var lineCommand = new LineCommand(inputLineParameters);
            
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("----------------------");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|xxxxxx              |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("----------------------");

            // act
            var actualCanvasString = PaintHandler.HandleOn(lineCommand);

            // assert
            Assert.Equal(stringBuilder.ToString(), actualCanvasString);
        }

        [Fact]
        public void HandleOn_InvalidLineParameter_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            var createCommand = new CreateCommand(inputParameters);
            PaintHandler.HandleOn(createCommand);

            var inputLineParameters = new[] {"L", "30", "2", "6", "2"};
            var lineCommand = new LineCommand(inputLineParameters);
            
            // act & assert
            Assert.Throws<ArgumentException>(() => PaintHandler.HandleOn(lineCommand));
        }

        [Fact]
        public void HandleOn_RectangleCommand_ReturnsDrawnCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            var createCommand = new CreateCommand(inputParameters);
            PaintHandler.HandleOn(createCommand);
            
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
            var actualCanvasString = PaintHandler.HandleOn(rectangleCommand);

            // assert
            Assert.Equal(stringBuilder.ToString(), actualCanvasString);
        }

        [Fact]
        public void HandleOn_InvalidRectangleCommand_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            var createCommand = new CreateCommand(inputParameters);
            PaintHandler.HandleOn(createCommand);
            
            var inputLineParameters = new[] {"R", "30", "1", "18", "3"};
            var rectangleCommand = new RectangleCommand(inputLineParameters);
            
            // act & assert
            Assert.Throws<ArgumentException>(() => PaintHandler.HandleOn(rectangleCommand));
        }

        [Fact]
        public void HandleOn_FloodFillCommand_ReturnsDrawnCanvas()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            var createCommand = new CreateCommand(inputParameters);
            PaintHandler.HandleOn(createCommand);
            
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
            var actualCanvasString = PaintHandler.HandleOn(floodFillCommand);
            
            // assert
            Assert.Equal(stringBuilder.ToString(), actualCanvasString);
        }

        [Fact]
        public void HandleOn_InvalidFillCommand_DoesNothing()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            var createCommand = new CreateCommand(inputParameters);
            PaintHandler.HandleOn(createCommand);
            
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
            var actualCanvasString = PaintHandler.HandleOn(floodFillCommand);
            
            // assert
            Assert.Equal(stringBuilder.ToString(), actualCanvasString);
        }

        [Fact]
        public void HandleOn_UndoCommand_RemovesFromHistoryAndAddsToCurrentState()
        {
            // arrange
            var inputParameters = new[] {"C", "20", "4"};
            var createCommand = new CreateCommand(inputParameters);
            var createString = PaintHandler.HandleOn(createCommand);

            var inputLineParameters = new[] {"L", "1", "2", "6", "2"};
            var lineCommand = new LineCommand(inputLineParameters);
            var lineCanvasString = PaintHandler.HandleOn(lineCommand);

            var inputCommandParameters = new []{"Z"};
            var undoCommand = new UndoCommand(inputCommandParameters);
            
            // act
            var undoString = PaintHandler.HandleOn(undoCommand);
            
            // assert
            Assert.NotEqual(lineCanvasString, undoString);
            Assert.Equal(createString, undoString);
        }
    }
}