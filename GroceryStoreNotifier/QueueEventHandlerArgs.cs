public delegate void QueueEventHandler(object sender, QueueEventHandlerArgs args);

public class QueueEventHandlerArgs : EventArgs
{
    private string customerName;
    private int positionInQueue;
    public string CustomerName { get => customerName; }
    public int PositionInQueue { get => positionInQueue; }

    public QueueEventHandlerArgs(string name, int position)
    {
        customerName = name;
        positionInQueue = position;
    }
}