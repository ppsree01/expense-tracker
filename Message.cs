internal static class Message {
    public static void Notify(string message) {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
    }

    public static void Introduce() {
        Console.WriteLine("\n\n");
        Message.Notify("Expense Tracker App");
        Console.WriteLine("----------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n");
        Console.WriteLine("Use `dotnet run` to run the app in combination \nwith below arguments to perform different operations on Expense tracker");
        Console.WriteLine("\n");
        Console.WriteLine("-- summary\nDisplays total expenses incurred ");
        Console.WriteLine("-- summary --month 2 --year 2025 --category food\nDisplays total expenses incurred for the given month, year, category");
        Console.WriteLine("\n");
        Console.WriteLine("-- add --amount 1250 --description instamart --category grocery\nAdds an amount of 1250 with description as instamart and category as grocery. \n- Category is optional, if not specified, it will default to general");
        Console.WriteLine("\n");
        Console.WriteLine("-- list\nLists all expenses so far");
        Console.WriteLine("\n");
        Console.WriteLine("-- delete --id 1\nDeletes the item with id 1");
        Console.WriteLine("\n");
        Console.WriteLine("-- budget --amount 1250\nSets a budget of 1250.");
    }
}