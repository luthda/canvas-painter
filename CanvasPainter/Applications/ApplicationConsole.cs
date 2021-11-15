namespace CanvasPainter.Applications
{
    public class ApplicationConsole : IApplicationConsole
    {
        public void Write(string output)
        {
            System.Console.Write(output);
        }

        public void WriteLine(string output)
        {
            System.Console.WriteLine(output);
        }

        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}