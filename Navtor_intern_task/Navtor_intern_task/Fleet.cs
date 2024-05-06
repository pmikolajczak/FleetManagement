namespace Navtor_intern_task;

public class Fleet(string shipownerName)
{
    private HashSet<Ship> Ships = [];
    private string _shipownerName = shipownerName;
    
    public void AddShip(Ship ship)
    {
        Ships.Add(ship);
    }
    
    public void RemoveShip(Ship ship)
    {
        Ships.Remove(ship);
    }
    
    public void PrintShips()
    {
        foreach (var ship in Ships)
        {
            Console.WriteLine(ship);
        }
    }
    
    public override string ToString()
    {
        var ships = string.Join("\n", Ships);
        return $"------{_shipownerName}'s fleet------\n{ships}\n--------------------------";
    }
}