using FleetManagementApp;

namespace FleetManagementAppTest;

public class ContainerShipTest
{

    
    [Fact]
    public void AddContainer_ShouldIncreaseCurrentLoad()
    {
        // Arrange
        var ship = new ContainerShip("IMO9356646", 
            "TEST", 
            17, 122, 
            new Position(new Tuple<double, double>(58.253531, 9.892320)), 
            8019);
        
        var container = new Container("CMAU1234567", "TEST","TEST", 100);

        // Act
        ship.AddContainer(container);

        // Assert
        Assert.Equal(100, ship.CurrentLoad);
    }
    
    [Fact]
    public void RemoveContainer_ShouldDecreaseCurrentLoad()
    {
        // Arrange
        var ship = new ContainerShip("IMO9356646", 
            "TEST", 
            17, 122, 
            new Position(new Tuple<double, double>(58.253531, 9.892320)), 
            8019);
        
        var container = new Container("CMAU1234567", "TEST","TEST", 100);
        ship.AddContainer(container);

        // Act
        ship.RemoveContainer(container);

        // Assert
        Assert.Equal(0, ship.CurrentLoad);
    }
    
    
    [Fact]
    public void RemoveContainer_ContainerDoesntExist_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var ship = new ContainerShip("IMO9356646", 
            "TEST", 
            17, 122, 
            new Position(new Tuple<double, double>(58.253531, 9.892320)), 
            8019);
        
        var container = new Container("CMAU1234567", "TEST","TEST", 100);
        ship.AddContainer(container);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => ship.RemoveContainer(new Container("CMAU1234568", "TEST","TEST", 100)));
    }
    
    [Fact]
    public void GetCurrentLoad_ShouldReturnCorrectLoad()
    {
        // Arrange
        var ship = new ContainerShip("9356646", 
            "TEST", 
            17, 122, 
            new Position(new Tuple<double, double>(58.253531, 9.892320)), 
            8019);
        var container1 = new Container("CMAU1234567", "TEST","TEST", 100);
        var container2 = new Container("CMAU1234567", "TEST","TEST", 200);
        ship.AddContainer(container1);
        ship.AddContainer(container2);

        // Act
        var load = ship.CurrentLoad;

        // Assert
        Assert.Equal(300, load);
    }

}