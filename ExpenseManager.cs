internal static class ExpenseManager {
    public static List<Expense> expenses = new List<Expense>();

    public static void LoadExpenses() {
        FileManager.CreateFile();
        expenses = FileManager.ReadFile();
    }

    public static void AddExpense(string description, double amount, string category = "") {
        int id = 0; 
        LoadExpenses();

        if (!CanAddExpense(amount)) return;

        if (expenses.Count > 0) {
            id = expenses.OrderByDescending(x => x.id).First().id + 1;
        }

        if (category != "") {
            var expenseWithCategory = new Expense {
                id = id,
                date = DateTime.Now,
                description = description,
                amount = amount,
                category = category
            };   
            FileManager.WriteToFile(new List<Expense> { expenseWithCategory });
        }
        else {
            var expense = new Expense {
                id = id,
                date = DateTime.Now,
                description = description,
                amount = amount
            };
            FileManager.WriteToFile(new List<Expense> { expense });
            Message.Notify($"Expense added successfully (ID: {id})");
        }
    }

    public static void SetBudget(double amount) {
        FileManager.CreateBudgetFile();
        FileManager.StoreBudget(amount);
    }

    private static bool CanAddExpense(double amount) {
        int month = DateTime.Now.Month;
        double currentTotal = expenses.Where(x => x.date.Month == month).Sum(x => x.amount);
        double budget = FileManager.GetBudget();
        if (budget == -1) return true;
        double budget_80_percent = budget * 0.8;
        double newTotal = currentTotal + amount;

        if (newTotal >= budget_80_percent && newTotal <= budget) {
            Console.WriteLine("Crossing 80% of the set budget for this month.. Buuut I'll allow it");
            return true;
        } else if (newTotal > budget) {
            Console.WriteLine("Oh shoot! Budget limit crossed. This operation is not allowed. Sorry");
            return false;
        } 
        return true;

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
            Console.WriteLine($"{item.id}\t{item.date}\t{item.category}\t{item.description}\t{item.amount}");
        }
    }

    public static void GetSummary(int month = -1, int year = -1, string category = "") {
        LoadExpenses();
        double total = 0;
        var filtered = expenses;

        if (category != "") {
            filtered = filtered.Where(x => x.category == category).ToList();
        }

        if (month != -1) {
            filtered = filtered.Where(x => x.date.Month == month).ToList();
        }

        if (year != -1) {
            filtered = filtered.Where(x => x.date.Year == year).ToList();
        }

        total = filtered.Sum(x => x.amount);
        Console.WriteLine($"Total Expenses: ${total}");
    }

}