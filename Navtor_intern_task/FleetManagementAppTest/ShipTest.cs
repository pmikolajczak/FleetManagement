using FleetManagementApp;

namespace FleetManagementAppTest;

public class ShipTest
{
    [Fact]
    public void Constructor_InvalidId_ThrowsArgumentException()
    {
        // Arrange
        string invalidId = "IMO8593506";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
            new ContainerShip(
                invalidId, "Test", 10, 20, 
                new Position(new Tuple<double, double>(58.253531, 9.892320)), 1000));
    }
    
    [Fact]
    public void Constructor_ValidId_SetsId()
    {
        // Arrange
        string validId = "IMO9356646";

        // Act
        var ship = new ContainerShip(
            validId, "Test", 10, 20, 
            new Position(new Tuple<double, double>(58.253531, 9.892320)), 1000);

        // Assert
        Assert.Equal(validId, ship.Id);
    }
    
}