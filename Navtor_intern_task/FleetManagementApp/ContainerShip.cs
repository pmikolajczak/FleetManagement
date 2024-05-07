namespace FleetManagementApp;

public class ContainerShip: Ship
{
    private double MaxLoad { get; } // in Tons
    private readonly List<Container> _containers = []; 
    public double CurrentLoad { get; private set; } // in Tons
    
    public ContainerShip(string id, string name, int width, int length, Position currentPosition, double maxLoad) 
        : base(id, name, width, length, currentPosition)
    {
        MaxLoad = maxLoad;
        CurrentLoad = 0;
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
               $"Type: Container Ship" +
               $"\n Containers:\n    {string.Join("\n    ", _containers)}\n";
    }

    public void AddContainer(Container newContainer)
    {
        if (CurrentLoad + newContainer.Weight > MaxLoad)
        {
            throw new InvalidOperationException("The container cannot be added, the ship is full");
        }
        
        _containers.Add(newContainer);
        CurrentLoad += newContainer.Weight;
    }
    
    public void RemoveContainer(Container container)
    {
        if (!_containers.Contains(container))
        {
            throw new InvalidOperationException("The container cannot be removed, it is not on the ship");
        }

        if (_containers.Count < 1)
        {
            throw new InvalidOperationException("The container cannot be removed, the ship is empty");
        }
        
        _containers.Remove(container);
        CurrentLoad -= container.Weight;
    }
    
    public Container GetContainerById(Guid containerId)
    {
        if(_containers.Any(container => container.Id == containerId))
        {
            return _containers.First(container => container.Id == containerId);
        }
        throw new InvalidOperationException("The container with the given ID does not exist");
    }
    
}