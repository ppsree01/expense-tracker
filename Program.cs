if (args.Length == 0) {
    Message.Introduce();
}
else {
    var command = args[0];
    int descriptionIndex = args.ToList().FindIndex(x => x == "--description");
    int amountIndex = args.ToList().FindIndex(x => x == "--amount");
    int idIndex = args.ToList().FindIndex(x => x == "--id");
    int monthIndex = args.ToList().FindIndex(x => x == "--month");
    int yearIndex = args.ToList().FindIndex(x => x == "--year");
    int categoryIndex = args.ToList().FindIndex(x => x == "--category");   
    string category = "";

    switch(command) {
        case "add":
            if (amountIndex == -1) 
            {
                Message.Notify("--amount argument missing");
                return;
            }

            if (descriptionIndex == -1) {
                Message.Notify("--description argument missing");
                return;
            }

            if (categoryIndex > -1) category = args[categoryIndex + 1]; 
            ExpenseManager.AddExpense(args[descriptionIndex + 1], Convert.ToInt32(args[amountIndex + 1]), category);

            break;
        case "list":
            ExpenseManager.List();
            break;
        case "summary":

            int month = monthIndex == -1 ? monthIndex : Convert.ToInt32(args[monthIndex + 1]);
            int year = yearIndex == -1 ? yearIndex : Convert.ToInt32(args[yearIndex + 1]);
            category = categoryIndex == -1 ? "" : args[categoryIndex + 1];
            
            ExpenseManager.GetSummary(month, year, category);
            break;
        case "delete":
            int id = Convert.ToInt32(args[idIndex + 1]);
            ExpenseManager.DeleteExpense(id);
            break;

        case "budget":
            double amount = Convert.ToDouble(args[amountIndex + 1]);
            ExpenseManager.SetBudget(amount);
            break;
    }
}