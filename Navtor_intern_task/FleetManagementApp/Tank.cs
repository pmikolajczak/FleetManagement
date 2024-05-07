namespace FleetManagementApp;

public class Tank()
{
    public double CurrentCapacity { get; private set; } // in Liters
    public double MaxCapacity { get; } // in Liters
    public FuelType Type { get; }
    public Guid Id { get; }


    public Tank(double maxCapacity, FuelType type) : this()
    {
        MaxCapacity = maxCapacity;
        Type = type;
        CurrentCapacity = 0;
        Id = Guid.NewGuid();
    }
    
    public int Refuel(double amount, FuelType type)
    {
        if (Type != type) return -1;

        if (CurrentCapacity + amount > MaxCapacity) return -1;
        
        CurrentCapacity += amount;
        return 0;
    }

    public override string ToString()
    {
        return $"Id: {Id}, " +
               $"Type: {Type}, " +
               $"MaxCapacity: {MaxCapacity}, " +
               $"CurrentCapacity: {CurrentCapacity}, " +
               $"Full of {double.Round(CurrentCapacity / MaxCapacity * 100, 2)}%";
    }

    public int Empty()
    {
        if (CurrentCapacity == 0) return -1;
        
        CurrentCapacity = 0;
        return 0;
    }
}