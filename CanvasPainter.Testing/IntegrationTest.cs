using System.Text;
using CanvasPainter.Handlers;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing
{
    public class IntegrationTest
    {
        private readonly PaintHandler _paintHandler;

        public IntegrationTest()
        {
            _paintHandler = new PaintHandler();
        }

        [Fact]
        public void IntegrationTest_ForScenarios_DrawsCanvas()
        {
            // arrange
            var inputValues = new string("C 20 4");

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("----------------------");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("----------------------");
            
            // act
            var createCommand = MessageFactory.CreateFor(inputValues);
            string canvas = _paintHandler.HandleOn(createCommand);
            
            // assert
            Assert.Equal(stringBuilder.ToString(), canvas);
            
            // arrange
            inputValues = new string("L 1 2 6 2");
           
            stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("----------------------");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|xxxxxx              |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("----------------------");
            
            // act
            var lineCommand = MessageFactory.CreateFor(inputValues);
            canvas = _paintHandler.HandleOn(lineCommand);
           
            // assert
            Assert.Equal(stringBuilder.ToString(), canvas);
            
            // arrange
            inputValues = new string("L 6 3 6 4");
            
            stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("----------------------");
            stringBuilder.AppendLine("|                    |");
            stringBuilder.AppendLine("|xxxxxx              |");
            stringBuilder.AppendLine("|     x              |");
            stringBuilder.AppendLine("|     x              |");
            stringBuilder.AppendLine("----------------------");
            
            // act
            var verticalLineCommand = MessageFactory.CreateFor(inputValues);
            canvas = _paintHandler.HandleOn(verticalLineCommand);
           
            // assert
            Assert.Equal(stringBuilder.ToString(), canvas);
            
            // arrange
            inputValues = new string("R 14 1 18 3");
            
            stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("----------------------");
            stringBuilder.AppendLine("|             xxxxx  |");
            stringBuilder.AppendLine("|xxxxxx       x   x  |");
            stringBuilder.AppendLine("|     x       xxxxx  |");
            stringBuilder.AppendLine("|     x              |");
            stringBuilder.AppendLine("----------------------");
            
            // act
            var rectangleCommand = MessageFactory.CreateFor(inputValues);
            canvas = _paintHandler.HandleOn(rectangleCommand);
            
            // assert
            Assert.Equal(stringBuilder.ToString(), canvas);
            
            // arrange
            inputValues = new string("B 10 3 o");
            
            stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("----------------------");
            stringBuilder.AppendLine("|oooooooooooooxxxxxoo|");
            stringBuilder.AppendLine("|xxxxxxooooooox   xoo|");
            stringBuilder.AppendLine("|     xoooooooxxxxxoo|");
            stringBuilder.AppendLine("|     xoooooooooooooo|");
            stringBuilder.AppendLine("----------------------");
            
            // act
            var floodFillCommand = MessageFactory.CreateFor(inputValues);
            canvas = _paintHandler.HandleOn(floodFillCommand);

            // assert
            Assert.Equal(stringBuilder.ToString(), canvas);
        }
    }
}