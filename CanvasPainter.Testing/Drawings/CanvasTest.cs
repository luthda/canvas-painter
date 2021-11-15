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
            Canvas = new Canvas(new CreateCommand(inputParameters));

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
            Canvas = new Canvas(new CreateCommand(inputParameters));

            var expectedString = new StringBuilder();
            expectedString.AppendLine("------");
            expectedString.AppendLine("|    |");
            expectedString.AppendLine("|    |");
            expectedString.AppendLine("------");

            // act
            var actualCanvas = Canvas.DrawBorder();

            // assert
            Assert.Equal(actualCanvas, expectedString.ToString());
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
    }
}