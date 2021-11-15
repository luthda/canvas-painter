using System;
using CanvasPainter.Commands;
using Xunit;

namespace CanvasPainter.Testing.Commands
{
    public class FloodFillCommandTest
    {
        public FloodFillCommand FloodFillCommand { get; set; }

        [Fact]
        public void ValidateAndSetProperties_WithValidParameters_SetsProperties()
        {
            // arrange
            var inputParameters = new string[] {"B", "10", "3", "o"};

            // act
            FloodFillCommand = new FloodFillCommand(inputParameters);

            // assert
            Assert.Equal(10, FloodFillCommand.ColorPoint.X);
            Assert.Equal(3, FloodFillCommand.ColorPoint.Y);
            Assert.Equal('o', FloodFillCommand.FillColor);
        }
        
        [Fact]
        public void ValidateAndSetProperties_WithInvalidParameters_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string[]{"B", "10", "2", "630"};
            
            // act & assert
            Assert.Throws<ArgumentException>(() => FloodFillCommand = new FloodFillCommand(inputParameters));
        }
        
        [Fact]
        public void ValidateAndSetProperties_WithTooShortParameters_ThrowsArgumentException()
        {
            // arrange
            var inputParameters = new string[]{"B", "10", "2"};
            
            // act & assert
            Assert.Throws<ArgumentException>(() => FloodFillCommand = new FloodFillCommand(inputParameters));
        }
    }
}