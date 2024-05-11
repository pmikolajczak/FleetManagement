using FleetManagementApp;
using FleetManagementApp.Exceptions;

namespace FleetManagementAppTest;

public class TankTest
{

    // [Theory]
    // [InlineData(10, FuelType.Diesel)]
    // [InlineData(100, FuelType.HeavyFuel)]
    // [InlineData(200, FuelType.HeavyFuel)]
    // public void EmptyFully_ValidAmount_DoesNotThrowException(double maxCapacity, FuelType type)
    // {
    //     
    //     var tank = new Tank(maxCapacity, type);
    //     var exception = Record.Exception(() => tank.EmptyFully());
    //     Assert.Null(exception);
    // }
    
    [Theory]
    [InlineData(10, FuelType.Diesel, 5)]
    [InlineData(100, FuelType.HeavyFuel, 50)]
    [InlineData(200, FuelType.HeavyFuel, 200)]
    public void EmptyPartially_ValidAmount_DoesNotThrowException(double maxCapacity, FuelType type, double amount)
    {
        var tank = new Tank(maxCapacity, type);
        tank.Refuel(amount);
        var exception = Record.Exception(() => tank.EmptyPartially(amount));
        Assert.Null(exception);
    }

    
    [Theory]
    [InlineData(10, FuelType.Diesel, 15)]
    [InlineData(100, FuelType.HeavyFuel, 150)]
    [InlineData(200, FuelType.HeavyFuel, 201)]
    public void EmptyPartially_InvalidAmount_ThrowsEmptyingTooMuchFuelException(double maxCapacity, FuelType type, double amount)
    {
        var tank = new Tank(maxCapacity, type);
        tank.Refuel(amount);
        Assert.Throws<EmptyingTooMuchFuelException>(() => tank.EmptyPartially(amount));
    }
    
    [Theory]
    [InlineData(10, FuelType.Diesel, 5)]
    [InlineData(100, FuelType.HeavyFuel, 50)]
    public void Refuel_ValidAmount_DoesNotThrowException(double maxCapacity, FuelType type, double amount)
    {
        var tank = new Tank(maxCapacity, type);
        var exception = Record.Exception(() => tank.Refuel(amount));
        Assert.Null(exception);
    }
    
    [Theory]
    [InlineData(10, FuelType.Diesel, 15)]
    [InlineData(100, FuelType.HeavyFuel, 150)]
    public void Refuel_InvalidAmount_ThrowsTankOverfillException(double maxCapacity, FuelType type, double amount)
    {
        var tank = new Tank(maxCapacity, type);
        Assert.Throws<TankOverfillException>(() => tank.Refuel(amount));
    }
    
}