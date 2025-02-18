if (args.Length > 0) {
    var command = args[0];
    int id = 0;
    string description = "";
    double amount = 0;

    switch(command) {
        case "add":
            if (args[1] == "--description") {
                description = args[2];
            }
            if (args[3] == "--amount") {
                amount = Convert.ToDouble(args[4]);
            }
            ExpenseManager.AddExpense(description, amount);
            break;
        case "list":
            ExpenseManager.List();
            break;
        case "summary":
            if (args.Length == 3) {
                if (args[1] == "--month") {
                    int month = Convert.ToInt32(args[2]);
                    ExpenseManager.GetSummary(month);
                }
                else if (args[1] == "--year") {
                    int year = Convert.ToInt32(args[2]);
                    ExpenseManager.GetSummary(-1, year);
                }
            }
            else if (args.Length == 5) {
                int month = Convert.ToInt32(args[2]);
                int year = Convert.ToInt32(args[4]);
                ExpenseManager.GetSummary(month, year);
            }
            else {
                ExpenseManager.GetSummary();
            }
            break;
        case "delete":
            if (args[1] == "--id") {
                id = Convert.ToInt32(args[2]);
            }
            ExpenseManager.DeleteExpense(id);
            break;
    }
}