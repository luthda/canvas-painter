using CanvasPainter.Exceptions;
using CanvasPainter.Handlers;
using CanvasPainter.Messages;

namespace CanvasPainter.Applications
{
    public class Application
    {
        private readonly IApplicationConsole _applicationConsole;
        private readonly PaintHandler _paintHandler;
        private bool IsQuit { get; set; }

        public Application()
        {
            _applicationConsole = new ApplicationConsole();
            _paintHandler = new PaintHandler();
            IsQuit = false;
        }

        public void Run()
        {
            while (!IsQuit)
            {
                try
                {
                    _applicationConsole.Write("Enter Commands: ");
                    var inputValues = _applicationConsole.ReadLine();
                    var message = MessageFactory.CreateFor(inputValues);

                    if (message is QuitMessage)
                    {
                        IsQuit = true;
                    }
                    else
                    {
                        _applicationConsole.Write(_paintHandler.HandleOn(message));
                    }
                       
                }
                catch (CanvasException ex)
                {
                    _applicationConsole.WriteLine(ex.Message);
                }
            }
        }
    }
}