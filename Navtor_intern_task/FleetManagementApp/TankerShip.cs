namespace FleetManagementApp;

public class TankerShip : Ship
{
    public double MaxLoad { get;} // in Tons
    public List<Tank> Tanks { get; } = [];
    public double CurrentLoad { get; private set; } // in Tons
    private const double DieselDensity = 0.85; // in kg/L
    private const double HeavyFuelDensity = 0.96; // in kg/L


    public TankerShip(string id, string name, int width, int length, Position currentPosition, double maxLoad) 
        : base(id, name, width, length, currentPosition)
    {
        CurrentLoad = 0;
        MaxLoad = maxLoad;
    }
    
    public void InstallTanks(List<Tank> tanks)
    {
        foreach (var tank in tanks)
        {
            Tanks.Add(tank);
        }
    }
    
    public override string ToString()
    {
        Position currentPosition = GetCurrentPosition();
        var currentTime = DateTime.Now;
        return $"Id: {Id}, " +
               $"Name: {Name}, " +
               $"Width: {Width}[m], " +
               $"Length: {Length}[m], " +
               $"Max Load: {MaxLoad}[T] " +
               $"Current Load: {CurrentLoad}[T] " +
               $"ActualCoordinate({(int)(currentTime - currentPosition.UpdateTime).TotalMinutes} min ago): {{{currentPosition.Coordinates.Item1}, " +
               $"{currentPosition.Coordinates.Item2}}}, " +
               $"Full of {double.Round(CurrentLoad/MaxLoad*100, 2)}% ," +
               $"Type: Tanker Ship" +
               $"\n Tanks:\n    {string.Join("\n    ", Tanks)}\n";
    }
    
    public void AddFuel(double amount, FuelType type)
    {
        double fuelWeightInTons = 0;

        switch (type)
        {
            case FuelType.Diesel:
                fuelWeightInTons = (DieselDensity * amount) * 0.001;
                break;
            case FuelType.HeavyFuel:
                fuelWeightInTons = (HeavyFuelDensity * amount) * 0.001;
                break;
            default:
                throw new InvalidOperationException("The fuel type is not valid");
        }

        if (CurrentLoad + fuelWeightInTons > MaxLoad)
        {
            throw new InvalidOperationException("The fuel cannot be added, the ship is full");
        }

        var tankFound = false;
        foreach (var tank in Tanks.Where(tank => tank.Type == type))
        {
            if (tank.Refuel(amount, type) == 0)
            {
                tankFound = true;
                CurrentLoad += fuelWeightInTons;
                break;
            }
        }

        if (!tankFound)
        {
            throw new InvalidOperationException("The fuel cannot be added, there is no tank installed for the fuel type");
        }
    }

    public void EmptyTank(Guid tankId)
    {
        var tank = Tanks.FirstOrDefault(tank => tank.Id == tankId);
        if (tank == null)
        {
            throw new InvalidOperationException("The tank cannot be emptied, the tank is not installed on the ship");
        }

        if (tank.CurrentCapacity == 0)
        {
            throw new InvalidOperationException("The tank cannot be emptied, the tank is empty");
        }

        if (tank.Type == FuelType.Diesel)
        {
            CurrentLoad -= tank.CurrentCapacity * DieselDensity * 0.001;
        }
        else
        {
            CurrentLoad -= tank.CurrentCapacity * HeavyFuelDensity * 0.001;
        }
        tank.Empty();
    }
}