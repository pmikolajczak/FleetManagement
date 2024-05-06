namespace FleetManagementApp;

internal static class Program { 
  
    public static void Main(string[] args) 
    {
        Console.WriteLine("Welcome to Fleet Management Console App");
        var fleet = new Fleet("MAERSK");
        InitializeFleetWithData(fleet);
        var isAppRunning = true;
        
        do
        {
            PrintMenu();
            var input = Console.ReadLine();
            var chosenOption = int.Parse(input ?? throw new InvalidOperationException());
            switch (chosenOption)
            {
                case 1:
                    Console.WriteLine("1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                case 3:
                    fleet.PrintShips();
                    break;
                case 4:
                    Console.Clear();
                    break;
                case 5:
                    isAppRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        } while (isAppRunning);
    }

    private static void InitializeFleetWithData(Fleet fleet)
    {
        var ship = new ContainerShip("1", "Titanic", 100, 200, new Tuple<double, double>(10.0, 20.0), 1000);
        var ship1 = new ContainerShip("2", "Titanic", 100, 200, new Tuple<double, double>(10.0, 20.0), 1000);
        fleet.AddShip(ship);
        fleet.AddShip(ship1);
    }

    private static void PrintMenu()
    {
        Console.WriteLine("1. Add Ship");
        Console.WriteLine("2. Remove Ship");
        Console.WriteLine("3. Print Ships");
        Console.WriteLine("4. Clear Console");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option: ");
    }
    
    
    
}