public class CashierQueue
{
    private Cashier cashier;
    public Cashier Cashier { get => cashier; }
    public event QueueEventHandler NewCustomerAdded;
    public event QueueEventHandler CustomerCalled;

    // private readonly Queue<string> queue = new();
    // private readonly Dictionary<string, Customer> customers = [];
    private readonly Queue<Customer> customers2 = new();

    public CashierQueue(Cashier cashier)
    {
        this.cashier = cashier;
        NewCustomerAdded += cashier.OnNewCustomer;
    }

    public void AddCustomer(string name, bool isVip = false)
    {
        Customer customer = new Customer(name, isVip);
        // customers[name] = customer;
        CustomerCalled += customer.OnCalled;

        if (isVip)
        {
            System.Console.WriteLine($"[Cashier {cashier.Name}]: VIP customers are served out of order.");
            CustomerCalled?.Invoke(this, new QueueEventHandlerArgs(name, 0));
            CustomerCalled -= customer.OnCalled;
            // customers.Remove(name);
        }
        else
        {
            customers2.Enqueue(customer);
            // queue.Enqueue(name);
            // NewCustomerAdded?.Invoke(this, new QueueEventHandlerArgs(name, queue.Count));
            NewCustomerAdded?.Invoke(this, new QueueEventHandlerArgs(name, customers2.Count));
        }
    }

    public void CallNext()
    {
        // if (queue.Count == 0)
        // {
        //     Console.WriteLine($"[Cashier {Cashier.Name}]: Queue is empty.");
        //     return;
        // }

        if (customers2.Count == 0)
        {
            Console.WriteLine($"[Cashier {Cashier.Name}]: Queue is empty.");
            return;
        }

        // string next = queue.Dequeue();
        // CustomerCalled?.Invoke(this, new QueueEventHandlerArgs(next, 0));

        Customer customer = customers2.Dequeue();
        CustomerCalled?.Invoke(this, new QueueEventHandlerArgs(customer.Name, 0));
        CustomerCalled -= customer.OnCalled;

        // if (customers.TryGetValue(next, out var customer))
        // {
        //     CustomerCalled -= customer.OnCalled;
        //     customers.Remove(next);
        // }
    }
}