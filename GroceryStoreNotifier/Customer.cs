public class Customer
{
    private string name;
    private bool isVip;
    public string Name { get => name; }
    public bool IsVip { get => isVip; }

    public Customer(string name, bool isVip = false)
    {
        this.name = name;
        this.isVip = isVip;
    }

    public void OnCalled(object sender, QueueEventHandlerArgs e)
    {
        if (e.CustomerName == Name)
        {
            string vip = IsVip ? "[VIP] " : "";
            System.Console.WriteLine($"{vip}[Customer {name}]: Your queue has come. Get to cashier.");
        }
    }
}