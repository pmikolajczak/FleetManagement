using FleetManagementApp;

namespace FleetManagementAppTest;

public class FleetTest
{
    private static Ship CreateValidContainerShip()
    {
        return new ContainerShip("IMO9224764", "test", 1, 1, 1, new Position(new Coordinates(1, 1), DateTime.Now));
    } 
    
    [Fact]
    public void Check_Adding_Ship()
    {
        var fleet = new Fleet("Test");
        var ship = CreateValidContainerShip();
        fleet.AddShip(ship);
        Assert.Contains(ship, fleet.Ships);

    }
    
    [Fact]
    public void Check_Removing_Ship()
    {
        var fleet = new Fleet("Test");
        var ship = CreateValidContainerShip();
        fleet.AddShip(ship);
        fleet.RemoveShip(ship.Id);
        Assert.DoesNotContain(ship, fleet.Ships);
    }
}