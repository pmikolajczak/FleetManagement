namespace Navtor_intern_task;

internal static class Program { 
  
    public static void Main(string[] args) 
    { 
        var ship = new Ship("1", "Titanic", 100, 200, new Tuple<double, double>(10.0, 20.0));
        var ship1 = new Ship("2", "Titanic", 100, 200, new Tuple<double, double>(10.0, 20.0));
        var fleet = new Fleet("ELOFJIFHNF");
        fleet.AddShip(ship);
        fleet.AddShip(ship1);
        Console.WriteLine(fleet);
        // Console.WriteLine(ship);
    } 
}