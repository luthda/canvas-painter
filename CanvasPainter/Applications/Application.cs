using System;
using System.Text;
using CanvasPainter.Commands;
using CanvasPainter.Drawings;
using CanvasPainter.Handlers;

namespace CanvasPainter.Applications
{
    public class Application
    {
        private readonly IApplicationConsole _applicationConsole;
        private readonly IHandler _paintHandler;
        private readonly QuitHandler _quiteHandler;
        private bool IsQuit { get; set; }

        public Application()
        {
            _applicationConsole = new ApplicationConsole();
            _paintHandler = new PaintHandler();
            _quiteHandler = new QuitHandler();
            IsQuit = false;
        }

        public void Run()
        {
            Start();
            while (!IsQuit)
            {
                try
                {
                    _applicationConsole.Write("Enter Commands: ");
                    var inputValues = _applicationConsole.ReadLine();
                    var command = CommandFactory.CreateFor(inputValues);
                    if (command.GetType() == typeof(QuitCommand))
                    {
                        IsQuit = _quiteHandler.HandleQuit((QuitCommand) command);
                    }
                    else _applicationConsole.Write(_paintHandler.HandleOn(command));
                }
                catch (Exception ex)
                {
                    _applicationConsole.WriteLine(ex.Message);
                }
            }
        }

        private void Start()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Following commands are possible:");
            stringBuilder.AppendLine("C w h           Should create a new canvas of width w and height h.");
            stringBuilder.AppendLine(
                "L x1 y1 x2 y2   Should create a new line from (x1,y1) to (x2,y2). Currently only horizontal or vertical lines are supported. Horizontal and vertical lines will be drawn using the 'x' character.");
            stringBuilder.AppendLine(
                "R x1 y1 x2 y2   Should create a new rectangle, whose upper left corner is (x1,y1) and lower right corner is (x2,y2). Horizontal and vertical lines will be drawn using the 'x' character.");
            stringBuilder.AppendLine(
                "B x y c         Should fill the entire area connected to (x,y) with 'colour' c. The behavior of this is the same as that of the 'bucket fill' tool in paint programs.");
            stringBuilder.AppendLine("Q               Should quit the program.");
            _applicationConsole.WriteLine(stringBuilder.ToString());
        }
    }
}