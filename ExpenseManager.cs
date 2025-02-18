using System.Numerics;

internal static class ExpenseManager {
    public static List<Expense> expenses = new List<Expense>();

    public static void LoadExpenses() {
        FileManager.CreateFile();
        expenses = FileManager.ReadFile();
    }

    public static void AddExpense(string description, double amount) {
        int id = 0; 
        LoadExpenses();
        Console.WriteLine(expenses.Count);
        if (expenses.Count > 0) {
            id = expenses.OrderByDescending(x => x.id).First().id + 1;
        }
        var expense = new Expense {
            id = id,
            date = DateTime.Now,
            description = description,
            amount = amount
        };
        FileManager.WriteToFile(new List<Expense> { expense });
        Message.Notify($"Expense added successfully (ID: {id})");
    }

    public static void DeleteExpense(int id) {
        LoadExpenses();
        expenses.RemoveAt(expenses.FindIndex(x => x.id == id));
        FileManager.WriteToFile(expenses, false);
        Message.Notify($"Expense deleted successfully");
    }

    public static void List() {
        LoadExpenses();
        foreach(var item in expenses) {
            Console.WriteLine($"{item.id}\t{item.date}\t{item.description}\t{item.amount}");
        }
    }

    public static void GetSummary(int month = -1, int year = -1) {
        LoadExpenses();
        double total = 0;
        if (month > -1 && year > -1) {
            total = expenses.Where(x => x.date.Month == month && x.date.Year == year).Sum(x => x.amount);
        }
        else if (month > -1) {
            total = expenses.Where(x => x.date.Month == month).Sum(x => x.amount);
        }
        else if (year > -1) {
            total = expenses.Where(x => x.date.Year == year).Sum(x => x.amount); 
        }
        else {
            total = expenses.Sum(x => x.amount);
        }
        Console.WriteLine($"Total Expenses: ${total}");
    }

}