using FleetManagementApp.Exceptions;

namespace FleetManagementApp;

public class Fleet
{
    public readonly HashSet<Ship> Ships = [];
    private string ShipOwner { get; set; }

    public Fleet(string shipOwner)
    {
        ShipOwner = shipOwner;
    }
    
    public void AddShip(Ship ship)
    {
        Ships.Add(ship);
    }
    
    public void RemoveShip(string id)
    {
        var ship = CheckIfShipExist(id);
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

    public Ship CheckIfShipExist(string shipId)
    {
        return Ships.FirstOrDefault(ship => ship.Id == shipId, null) ?? 
               throw new InvalidShipIdException("Ship not found");
    }
}