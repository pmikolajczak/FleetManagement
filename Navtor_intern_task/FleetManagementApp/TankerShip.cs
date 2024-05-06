namespace FleetManagementApp;

public class TankerShip : Ship
{
    private int MaxCapacity { get;}
    private List<Tank> Tanks = [];
    
    public TankerShip(string? id, string? name, int width, int length, Tuple<double, double>? actualCoordinate, int maxCapacity) : base(id, name, width, length, actualCoordinate)
    {
        MaxCapacity = maxCapacity;
    }
    
    public TankerShip(){}
}