using CanvasPainter.Commands;
using CanvasPainter.Handlers;
using Xunit;

namespace CanvasPainter.Testing.Handlers
{
    public class QuitHandlerTest
    {
        public QuitHandlerTest()
        {
            QuitHandler = new QuitHandler();
        }

        private QuitHandler QuitHandler { get; set; }
        [Fact]
        public void HandleOn_QuitCommand_ReturnsTrue()
        {
            // arrange
            var inputParameters = new string[] {"Q"};
            var quitCommand = new QuitCommand(inputParameters);
            
            // act
            var isQuit = QuitHandler.HandleQuit(quitCommand);
            
            // assert
            Assert.True(isQuit);
        }
    }
}