namespace FleetManagementApp;

public class Fleet
{
    private HashSet<Ship> Ships = [];
    private string ShipOwner { get; set; }

    public Fleet(string shipOwner)
    {
        ShipOwner = shipOwner;
    }
    
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
        return $"------{ShipOwner}'s fleet------\n{ships}\n--------------------------";
    }
}