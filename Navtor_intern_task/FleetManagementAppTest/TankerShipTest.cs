using FleetManagementApp;

namespace FleetManagementAppTest;

public class TankerShipTest
{

    [Fact]
    public void Constructor_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var id = "IMO9356646";
        var name = "Test Ship";
        var width = 10;
        var length = 20;
        var currentPosition = new Position(new Tuple<double, double>(58.253531, 9.892320));
        var maxLoad = 10000;

        // Act
        var tankerShip = new TankerShip(id, name, width, length, currentPosition, maxLoad);

        // Assert
        Assert.Equal(id, tankerShip.Id);
        Assert.Equal(name, tankerShip.Name);
        Assert.Equal(width, tankerShip.Width);
        Assert.Equal(length, tankerShip.Length);
        Assert.Equal(currentPosition, tankerShip.GetCurrentPosition());
        Assert.Equal(maxLoad, tankerShip.MaxLoad);
    }
    
    [Fact]
    public void Constructor_InvalidId_ThrowsArgumentException()
    {
        // Arrange
        string invalidId = "IMO8593506";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new TankerShip(invalidId, "Test", 10, 20, new Position(new Tuple<double, double>(58.253531, 9.892320)), 1000));
    }
    
    [Fact]
    public void Refueling_ShouldIncreaseCurrentLoad()
    {
        // Arrange
        const double dieselDensity = 0.85;
        
        var tankerShip = new TankerShip("IMO9356646", 
            "Test Ship", 
            10, 20, 
            new Position(new Tuple<double, double>(58.253531, 9.892320)), 
            10000);
        tankerShip.InstallTanks([
            new Tank(10000, FuelType.Diesel)
        ]);

        // Act
        tankerShip.AddFuel(1000, FuelType.Diesel);

        // Assert
        Assert.Equal(1000*dieselDensity*0.001, tankerShip.CurrentLoad);
    }
    
    [Fact]
    public void Overloading_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var tankerShip = new TankerShip("IMO9356646", 
            "Test Ship", 
            10, 20, 
            new Position(new Tuple<double, double>(58.253531, 9.892320)), 
            10000);
        tankerShip.InstallTanks([
            new Tank(10000, FuelType.Diesel)
        ]);

        // Act
        tankerShip.AddFuel(10000, FuelType.Diesel);

        // Assert
        Assert.Throws<InvalidOperationException>(() => tankerShip.AddFuel(1, FuelType.Diesel));
    }
    
    
    [Fact]
    public void Refueling_WithInvalidFuelType_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var tankerShip = new TankerShip("IMO9356646", 
            "Test Ship", 
            10, 20, 
            new Position(new Tuple<double, double>(58.253531, 9.892320)), 
            10000);
        tankerShip.InstallTanks([
            new Tank(10000, FuelType.Diesel)
        ]);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => tankerShip.AddFuel(1000, FuelType.HeavyFuel));
    }
    
    
    [Fact]
    public void Emptying_ShouldDecreaseCurrentLoad()
    {
        // Arrange
        const double dieselDensity = 0.85;
        
        var tankerShip = new TankerShip("IMO9356646", 
            "Test Ship", 
            10, 20, 
            new Position(new Tuple<double, double>(58.253531, 9.892320)), 
            10000);
        tankerShip.InstallTanks([
            new Tank(10000, FuelType.Diesel),
            new Tank(10000, FuelType.HeavyFuel)
        ]);

        // Act
        tankerShip.AddFuel(20, FuelType.Diesel);
        tankerShip.AddFuel(1000, FuelType.Diesel);
        tankerShip.AddFuel(1000, FuelType.HeavyFuel);
        double currentLoad = tankerShip.CurrentLoad;
        Tank tankToEmpty = tankerShip.Tanks.First();
        double expectedLoad = currentLoad - (tankToEmpty.CurrentCapacity * dieselDensity * 0.001);

        // Act
        tankerShip.EmptyTank(tankToEmpty.Id);
        

        // Assert
        Assert.Equal(expectedLoad, tankerShip.CurrentLoad);
    }
    
    [Fact]
    public void Emptying_WithInvalidTankId_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var tankerShip = new TankerShip("IMO9356646", 
            "Test Ship", 
            10, 20, 
            new Position(new Tuple<double, double>(58.253531, 9.892320)), 
            10000);
        tankerShip.InstallTanks([
            new Tank(10000, FuelType.Diesel),
            new Tank(10000, FuelType.HeavyFuel)
        ]);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => tankerShip.EmptyTank(Guid.NewGuid()));
    }
    
}
    