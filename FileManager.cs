internal static class FileManager {
    public static string configPath = Directory.GetCurrentDirectory() + "/config.txt";
    public static string path = Directory.GetCurrentDirectory() + "/data.csv";

    public static void CreateBudgetFile() {
        if (!File.Exists(configPath)) {
            File.Create(configPath).Close();
        }
    }

    public static void StoreBudget(double budget) {
        Console.WriteLine(budget);
        using (StreamWriter sw = new StreamWriter(configPath, false)) {
            sw.WriteLine(budget);
        }
    }

    public static double GetBudget() {
        FileManager.CreateBudgetFile();
        string[] lines = File.ReadAllLines(configPath);
        if (lines == null || lines.Count() == 0) {
            return -1;
        }
        return Convert.ToDouble(lines[0]);
    }

    public static void CreateFile() {
        if (!File.Exists(path)) {
            File.Create(path).Close();
        }
    }

    public static void WriteToFile(List<Expense> expenses, bool append = true) {
        using(StreamWriter sw = new StreamWriter(path, append)) {
            foreach(var expense in expenses) {
                sw.WriteLine($"{expense.id},{expense.date},{expense.category},{expense.description},{expense.amount}");
            }
        }
    }

    public static List<Expense> ReadFile() {
        List<Expense> expenses = new List<Expense>();
        string[] lines = File.ReadAllLines(path);
        foreach(var line in lines) {
            string[] input = line.Split(",");
            expenses.Add(new Expense {
                id = Convert.ToInt32(input[0]),
                date = Convert.ToDateTime(input[1]),
                category = input[2],
                description = Convert.ToString(input[3]),
                amount = Convert.ToDouble(input[4]),
            });
        }
        return expenses;
    }
}