internal static class FileManager {

    public static string path = Directory.GetCurrentDirectory() + "/data.csv";
    public static void CreateFile() {
        if (!File.Exists(path)) {
            File.Create(path).Close();
        }
    }

    public static void WriteToFile(List<Expense> expenses, bool append = true) {
        using(StreamWriter sw = new StreamWriter(path, append)) {
            foreach(var expense in expenses) {
                sw.WriteLine($"{expense.id},{expense.date},{expense.description},{expense.amount}");
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
                description = Convert.ToString(input[2]),
                amount = Convert.ToDouble(input[3])
            });
        }
        return expenses;
    }
}