public class Program
{
    public static void Main()
    {
        QueueService service = new();
        // service.RegisterCashier("1", "Cashier1");
        // service.RegisterCashier("2", "Cashier2");

        System.Console.WriteLine($"[System]: Enter command to begin.");
        while (true)
        {
            string? s = Console.ReadLine();
            if (!string.IsNullOrEmpty(s))
            {
                if (s.StartsWith("next", StringComparison.CurrentCultureIgnoreCase))
                {
                    service.CallNext();
                }
                else if (s.StartsWith("add ", StringComparison.CurrentCultureIgnoreCase))
                {
                    string[] str = s.Split(" ");
                    if (str.Length < 3)
                    {
                        System.Console.WriteLine($"[Error]: Invalid amount of arguments.");
                        continue;
                    }
                    else
                    {
                        bool vip = false;
                        if (str.Length >= 4 && str[3].Equals("vip", StringComparison.CurrentCultureIgnoreCase))
                        {
                            vip = true;
                        }
                        service.AddCustomer(str[2], str[1], vip);
                    }
                }
                else if (s.StartsWith("addc", StringComparison.CurrentCultureIgnoreCase))
                {
                    string[] str = s.Split(" ");
                    if (str.Length < 3)
                    {
                        System.Console.WriteLine($"[Error]: Invalid amount of arguments.");
                        continue;
                    }
                    else
                    {
                        service.RegisterCashier(str[2], str[1]);
                    }
                }
                else if (s.StartsWith("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    System.Console.WriteLine(
                        $"[Command]: help - list available commands.\n" +
                        $"[Command]: next - run program iteration.\n" +
                        $"[Command]: add  - add new customer to queue. Format: \"add <name> <cashierId> [vip]\n" +
                        $"[Command]: addc - add new cashier. Format: \"add <name> <cashierId>\n" +
                        $"[Command]: exit - exit program."
                        );
                }
                else if (s.StartsWith("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    return;
                }
                else
                {
                    System.Console.WriteLine($"[Error]: Unknown command.");
                }
            }
        }
    }
}
