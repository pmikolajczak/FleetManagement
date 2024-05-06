namespace FleetManagementApp;

public class ContainerShip: Ship
{
    public int MaxLoad { get; }
    private List<Container> Containers = [];
    
    public ContainerShip(string? id, string? name, int width, int length, Tuple<double, double>? actualCoordinate, int maxLoad) : base(id, name, width, length, actualCoordinate)
    {
        MaxLoad = maxLoad;
    }
    
    public ContainerShip(){}
    
}