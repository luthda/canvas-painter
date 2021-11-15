using System;
using CanvasPainter.Commands;
using Xunit;

namespace CanvasPainter.Testing.Commands
{
    public class LineCommandTest
    {
        public LineCommand LineCommand { get; set; }
        
        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new string[]{"L", "1", "2", "6", "2"};
            
            // act
            LineCommand = new LineCommand(inputParameters);
            
            // assert
            Assert.Equal(1,LineCommand.StartPoint.X);
            Assert.Equal(6,LineCommand.EndPoint.X);
            Assert.Equal(2,LineCommand.StartPoint.Y);
            Assert.Equal(2,LineCommand.EndPoint.Y);
        }

        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string[]{"L", "1", "2", "6", "4"};
            
            // act & assert
            Assert.Throws<ArgumentException>(() => LineCommand = new LineCommand(inputParameters));
        }

        [Fact]
        public void ValidateAndSetProperties_WithTooShortParameters_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string[]{"L", "1", "2", "6"};
            
            // act & assert
            Assert.Throws<ArgumentException>(() => LineCommand = new LineCommand(inputParameters));
        }
    }
}