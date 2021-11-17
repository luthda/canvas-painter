using CanvasPainter.Commands;
using CanvasPainter.Exceptions;
using Xunit;

namespace CanvasPainter.Testing.Commands
{
    public class RectangleCommandTest
    {
        private RectangleCommand RectangleCommand { get; set; }

        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new[] {"R", "14", "1", "18", "3"};

            // act
            RectangleCommand = new RectangleCommand(inputParameters);

            // assert
            Assert.Equal(14, RectangleCommand.StartPoint.X);
            Assert.Equal(18, RectangleCommand.EndPoint.X);
            Assert.Equal(1, RectangleCommand.StartPoint.Y);
            Assert.Equal(3, RectangleCommand.EndPoint.Y);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsValidationException()
        {
            // arrange
            var inputParameters = new[] {"R", "1", "2", "6"};

            // act & assert
            Assert.Throws<ValidationException>(() => RectangleCommand = new RectangleCommand(inputParameters));
        }
    }
}