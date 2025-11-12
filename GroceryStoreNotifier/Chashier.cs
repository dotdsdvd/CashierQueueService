public class Cashier
{
    private string id;
    private string name;
    public string Id { get => id; }
    public string Name { get => name; }

    public Cashier(string id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public void OnNewCustomer(object sender, QueueEventHandlerArgs arg)
    {
        System.Console.WriteLine($"[Cashier {name}]: Customer {arg.CustomerName} waiting at #{arg.PositionInQueue}.");
    }
}