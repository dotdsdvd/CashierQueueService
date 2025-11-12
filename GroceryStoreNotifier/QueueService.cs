public class QueueService
{
    private readonly Dictionary<string, CashierQueue> queueCashiers = new Dictionary<string, CashierQueue>();
    public void RegisterCashier(string id, string name)
    {
        Cashier cashier = new Cashier(id, name);
        CashierQueue cq = new CashierQueue(cashier);
        queueCashiers[id] = cq;
        System.Console.WriteLine($"[System]: Registered cashier {cashier} with id {id}");
    }
    public void AddCustomer(string cashierId, string customerName, bool isVip = false)
    {
        if (queueCashiers.TryGetValue(cashierId, out var cq))
        {
            cq.AddCustomer(customerName, isVip);
        }
        else
        {
            System.Console.WriteLine($"[Error]: Cashier with id \"{cashierId}\" not found.");
        }
    }

    public void CallNext(string cashierId)
    {
        if (queueCashiers.TryGetValue(cashierId, out var cq))
        {
            cq.CallNext();
        }
        else
        {
            System.Console.WriteLine($"[Error]: Cashier with id \"{cashierId}\" not found.");
        }
    }

    public void CallNext()
    {
        foreach(var i in queueCashiers.Keys)
        {
            CallNext(i);
        }
    }
}