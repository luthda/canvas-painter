using System;

namespace CanvasPainter.Applications
{
    public class ApplicationConsole : IApplicationConsole
    {
        public void Write(string output)
        {
            Console.Write(output);
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public string ReadLine()
        {
            return Console.ReadLine() ?? throw new InvalidOperationException();
        }
    }
}