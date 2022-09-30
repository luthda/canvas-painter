namespace CanvasPainter.Messages
{
    public interface IMessage
    {
        public void ValidateAndSetProperties(string[] inputParameters);
    }
}