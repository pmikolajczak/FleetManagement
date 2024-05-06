using FleetManagementApp;

namespace FleetManagementAppTest;

public class ShipTest
{
    [Fact]
    public void Test_ID_Validation_Valid()
    {
        // Arrange
        var ship = new ContainerShip();

        // Act
        int result = ship.SetId("IMO9593505");

        // Assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void Test_ID_Validation_Invalid()
    {
        // Arrange
        var ship = new ContainerShip();

        // Act
        int result = ship.SetId("IMO8593506");

        // Assert
        Assert.Equal(-1, result);
    }
    
}