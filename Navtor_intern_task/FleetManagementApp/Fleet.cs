namespace FleetManagementApp;

public class Fleet
{
    public HashSet<Ship> Ships = [];
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

    public Ship GetShipByID(string shipId)
    {
        if(Ships.Any(ship => ship.Id == shipId))
        {
            return Ships.First(ship => ship.Id == shipId);
        }
        throw new InvalidOperationException("The ship with the given ID does not exist");
    }
}