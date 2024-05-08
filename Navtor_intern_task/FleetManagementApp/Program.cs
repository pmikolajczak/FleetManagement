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
                    AddShipToFleet(fleet);
                    break;
                case 2:
                    RemoveShip(fleet);
                    break;
                case 3:
                    Console.WriteLine(fleet);
                    break;
                case 4:
                    Console.Write("Enter ship ID: ");
                    var shipId = Console.ReadLine();
                    ManageSpecificShip(shipId, fleet);
                    break;
                case 5:
                    Console.Clear();
                    break;
                case 6:
                    isAppRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        } while (isAppRunning);
    }

    private static void RemoveShip(Fleet fleet)
    {
        Console.Write("Enter ship ID: ");
        var shipId = Console.ReadLine();
        try
        {
            var ship = fleet.GetShipByID(shipId);
            fleet.RemoveShip(ship);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void InitializeFleetWithData(Fleet fleet)
    {
        // adding Tanker Ship with 2 tanks
        var ship = new TankerShip(
            "IMO9356646", "TANKER BEE 11", 
            17, 122, new Position(new Tuple<double, double>(58.253531, 9.892320)), 
            8019);
        ship.InstallTanks([
            new Tank(2000, FuelType.Diesel),
            new Tank(2000, FuelType.HeavyFuel)
        ]);
        ship.AddFuel(1000, FuelType.Diesel);
        ship.AddFuel(1000, FuelType.HeavyFuel);
        fleet.AddShip(ship);
        
        
        var ship1 = new ContainerShip(
            "IMO9839210", "CMA CGM SORBONNE", 62, 400, 
            new Position(new Tuple<double, double>(56.167121, 17.442068)), 221251);
        ship1.AddContainer(new Container(
            "Global Shipping Inc.",
            "Tech Innovations Ltd., UK, ",
            "High-tech electronics and components",
            1.43
        ));
        ship1.AddContainer(new Container(
            "Oceanic Freight Services",
            "Green Energy Solutions",
            "Solar panels and wind turbines",
            200
        ));
        fleet.AddShip(ship1);
    }

    private static void PrintMenu()
    {
        Console.WriteLine("1. Add Ship");
        Console.WriteLine("2. Remove Ship");
        Console.WriteLine("3. Print Ships");
        Console.WriteLine("4. Manage Specific Ship");
        Console.WriteLine("5. Clear Console");
        Console.WriteLine("6. Exit");
        Console.Write("Choose an option: ");
    }

    private static void ManageSpecificShip(string shipId, Fleet fleet)
    {
        try
        {
            var ship = fleet.GetShipByID(shipId);
            if (ship.GetType() == typeof(TankerShip))
            {
                bool goBack = false;

                do
                {
                    Console.WriteLine("1. Add Fuel");
                    Console.WriteLine("2. Remove Fuel");
                    Console.WriteLine("3. Print Ship");
                    Console.WriteLine("4. Back");
                    Console.Write("Choose an option: ");
                    var input = Console.ReadLine();
                    var chosenOption = int.Parse(input ?? throw new InvalidOperationException());
                    switch (chosenOption)
                    {
                        case 1:
                            Console.Write("Enter fuel amount: ");
                            var amount = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                            Console.Write("Enter fuel type (1 - Diesel, 2 - Heavy Fuel): ");
                            var fuelType = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                            ((TankerShip) ship).AddFuel(amount, fuelType == 1 ? FuelType.Diesel : FuelType.HeavyFuel);
                            break;
                        case 2:
                            Console.Write("Enter tank ID: ");
                            var tankId = Console.ReadLine();
                            ((TankerShip) ship).EmptyTank(Guid.Parse(tankId));
                            break;
                        case 3:
                            Console.WriteLine(ship);
                            break;
                        case 4:
                            goBack = true;
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }

                } while (!goBack);
            }
            else if (ship.GetType() == typeof(ContainerShip))
            {
                bool goBack = false;

                do
                {
                    Console.WriteLine("1. Add Container");
                    Console.WriteLine("2. Remove Container");
                    Console.WriteLine("3. Print Ship");
                    Console.WriteLine("4. Back");
                    Console.Write("Choose an option: ");
                    var input = Console.ReadLine();
                    var chosenOption = int.Parse(input ?? throw new InvalidOperationException());
                    string? owner, destination, content;
                    double weight;
                    switch (chosenOption)
                    {
                        case 1:
                            Console.Write("Enter container owner: ");
                            owner = Console.ReadLine();
                            Console.Write("Enter container destination: ");
                            destination = Console.ReadLine();
                            Console.Write("Enter container content: ");
                            content = Console.ReadLine();
                            Console.Write("Enter container weight: ");
                            weight = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                            ((ContainerShip) ship).AddContainer(new Container(owner!, destination!, content!, weight));
                            break;
                        case 2:
                            Console.Write("Enter ContainerID you want to remove: ");
                            var containerId = Guid.Parse(Console.ReadLine());
                            ((ContainerShip) ship).RemoveContainer(((ContainerShip) ship).GetContainerById(containerId));
                            break;
                        case 3:
                            Console.WriteLine(ship);
                            break;
                        case 4:
                            goBack = true;
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                } while (!goBack);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void AddShipToFleet(Fleet fleet)
    {
        Console.Write("Enter ship type (1 - Tanker Ship, 2 - Container Ship): ");
        var shipType = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Console.Write("Enter ship ID: ");
        var id = Console.ReadLine();
        Console.Write("Enter ship name: ");
        var name = Console.ReadLine();
        Console.Write("Enter ship width: ");
        var width = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Console.Write("Enter ship length: ");
        var length = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Console.Write("Enter ship current position (latitude): ");
        var latitude = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Console.Write("Enter ship current position (longitude): ");
        var longitude = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Console.Write("Enter ship max load: ");
        var maxLoad = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

        if (shipType == 1)
        {
            try
            {
                var ship = new TankerShip(id!, name!, width, length,
                    new Position(new Tuple<double, double>(latitude, longitude)), maxLoad);
                Console.Write("Enter number of tanks: ");
                var numberOfTanks = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                for (var i = 0; i < numberOfTanks; i++)
                {
                    Console.Write("Enter tank capacity: ");
                    var capacity = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    Console.Write("Enter tank type (1 - Diesel, 2 - Heavy Fuel): ");
                    var tankType = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    ship.InstallTanks([new Tank(capacity, tankType == 1 ? FuelType.Diesel : FuelType.HeavyFuel)]);
                }
                fleet.AddShip(ship);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        else if (shipType == 2)
        {
            try
            {
                var ship = new ContainerShip(id!, name!, width, length,
                    new Position(new Tuple<double, double>(latitude, longitude)), maxLoad);
                fleet.AddShip(ship);
                
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("Invalid ship type!");
        }
    }
}