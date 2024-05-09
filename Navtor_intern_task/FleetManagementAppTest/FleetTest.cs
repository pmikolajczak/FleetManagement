using FleetManagementApp;

namespace FleetManagementAppTest;

public class FleetTest
{
    [Fact]
    public void Check_Adding_Ship()
    {
        // Arrange
        var fleet = new Fleet("Test");

        // Act
        var ship = new TankerShip(
            "IMO9356646",
            "TANKER BEE 11",
            17, 122,
            new Position(new Tuple<double, double>(58.253531, 9.892320), DateTime.Now),
            8019);

        fleet.AddShip(ship);

        // Assert
        Assert.Contains(ship, fleet.Ships);
    }
    
    [Fact]
    public void Check_Removing_Ship()
    {
        // Arrange
        var fleet = new Fleet("Test");

        // Act
        var ship = new TankerShip(
            "IMO9356646",
            "TANKER BEE 11",
            17, 122,
            new Position(new Tuple<double, double>(58.253531, 9.892320), DateTime.Now),
            8019);

        fleet.AddShip(ship);
        fleet.RemoveShip(ship);

        // Assert
        Assert.DoesNotContain(ship, fleet.Ships);
    }
    
    [Fact]
    public void Check_That_Added_Ship_Fields_Are_Correct()
    {
        // Arrange
        var fleet = new Fleet("Test");

        // Act
        var ship = new TankerShip(
            "IMO9356646",
            "TANKER BEE 11",
            17, 122,
            new Position(new Tuple<double, double>(58.253531, 9.892320)),
            8019);

        fleet.AddShip(ship);

        // Assert
        Assert.Equal("IMO9356646", ship.Id);
        Assert.Equal("TANKER BEE 11", ship.Name);
        Assert.Equal(58.253531, ship.GetCurrentPosition().Coordinates.Item1);
        Assert.Equal(9.892320, ship.GetCurrentPosition().Coordinates.Item2);
        Assert.Equal(8019, ship.MaxLoad);
    }
    
    
    [Fact]
    public void GetShipByID_InvalidId_ThrowsArgumentException()
    {
        // Arrange
        var fleet = new Fleet("Test");

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => fleet.GetShipByID("IMO8593506"));
    }

    [Fact]
    public void GetShipByID_ValidId_ReturnsShip()
    {
        // Arrange
        var fleet = new Fleet("Test");

        // Act
        var ship = new TankerShip(
            "IMO9356646",
            "TANKER BEE 11",
            17, 122,
            new Position(new Tuple<double, double>(58.253531, 9.892320)),
            8019);

        fleet.AddShip(ship);

        // Assert
        Assert.Equal(ship, fleet.GetShipByID("IMO9356646"));
    }
}