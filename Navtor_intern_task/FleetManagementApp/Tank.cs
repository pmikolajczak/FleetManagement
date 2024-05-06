namespace FleetManagementApp;

public record Tank(string MaxCapacity, FuelType Type, Guid Id)
{
    public Tank(string maxCapacity, FuelType type)
        : this(maxCapacity, type, Guid.NewGuid())
    {
    }
}