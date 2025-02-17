internal class Expense {
    public int id { get; set; }
    public DateTime date { get; set; }
    public string description { get; set; } = "";
    public double amount {get; set; } = 0.0;
}