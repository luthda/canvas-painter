namespace CanvasPainter.Applications
{
    public interface IApplicationConsole
    {
        public void Write(string output);
        public void WriteLine(string output);
        public string ReadLine();
    }
}