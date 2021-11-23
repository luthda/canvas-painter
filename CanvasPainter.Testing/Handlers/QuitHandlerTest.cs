using CanvasPainter.Handlers;
using CanvasPainter.Messages;
using Xunit;

namespace CanvasPainter.Testing.Handlers
{
    public class QuitHandlerTest
    {
        private QuitHandler QuitHandler { get; set; }
        
        public QuitHandlerTest()
        {
            QuitHandler = new QuitHandler();
        }
        [Fact]
        public void HandleOn_QuitCommand_ReturnsTrue()
        {
            // arrange
            var inputParameters = new string[] {"Q"};
            var quitCommand = new QuitMessage(inputParameters);
            
            // act
            var isQuit = QuitHandler.HandleQuit(quitCommand);
            
            // assert
            Assert.True(isQuit);
        }
    }
}