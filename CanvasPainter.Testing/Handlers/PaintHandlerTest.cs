using System;
using System.Text;
using CanvasPainter.Commands;
using CanvasPainter.Handlers;
using Xunit;

namespace CanvasPainter.Testing.Handlers
{
    public class PaintHandlerTest
    {
        public PaintHandler PaintHandler { get; set; }

        public PaintHandlerTest()
        {
            PaintHandler = new PaintHandler();
        }
        
        [Fact]
        public void HandleOn_CreateCommand_ReturnsDrawnCanvas()
        {
            // arrange
            var inputParameters = new string[] {"C", "20", "4"};
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
        public void HandleOn_InvalidCommand_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string[] {"Q"};
            var quitCommand = new QuitCommand(inputParameters);
            
            // act & assert
            Assert.Throws<ArgumentException>(() => PaintHandler.HandleOn(quitCommand));
        }

        [Fact]
        public void HandleOn_LineCommand_ReturnsDrawnCanvas()
        {
            // arrange
            var inputParameters = new string[] {"C", "20", "4"};
            var createCommand = new CreateCommand(inputParameters);
            PaintHandler.HandleOn(createCommand);
            
            var inputLineParameters = new string[] {"L", "1", "2", "6", "2"};
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
    }
}