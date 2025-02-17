internal static class ExpenseManager {
    public static List<Expense> expenses = new List<Expense>();

    public static void AddExpense(string description, double amount) {
        int id = 0; 
        if (expenses.Count > 0) {
            id = expenses.OrderByDescending(x => x.id).First().id;
        }
        expenses.Add(new Expense {
            id = id,
            date = DateTime.Now,
            description = description,
            amount = amount
        });
        Message.Notify($"Expense added successfully (ID: {id})");
    }

    public static void DeleteExpense(int id) {
        foreach(var item in expenses) {
            if (item.id == id) expenses.Remove(item);
        }
        Message.Notify($"Expense deleted successfully");
    }

    public static void List() {
        foreach(var item in expenses) {
            Console.WriteLine($"{item.id}\t{item.date}\t{item.description}\t{item.amount}");
        }
    }

    public static void GetSummary() {
        var total = expenses.Sum(x => x.amount);
        Console.WriteLine($"Total Expenses: ${total}");
    }

}