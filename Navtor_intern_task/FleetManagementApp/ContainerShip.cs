using FleetManagementApp.Exceptions;

namespace FleetManagementApp;

public class ContainerShip: Ship
{
    public readonly List<Container> Containers = []; 
    
    public ContainerShip(string id, string name, int widthM, int lengthM, double maxLoadKg, Position currentPosition) 
        : base(id, name, widthM, lengthM, maxLoadKg, currentPosition)
    {
    }
    
    public override string ToString()
    {
        Position currentPosition = GetCurrentPosition();
        var currentTime = DateTime.Now;
        return $"Id: {Id}, " +
               $"Name: {Name}, " +
               $"Width: {WidthM}[m], " +
               $"Length: {LengthM}[m], " +
               $"Max Load: {MaxLoadKg}[T] " +
               $"Current Load: {CurrentLoadKg}[T] " +
               $"ActualCoordinate({(int)(currentTime - currentPosition.RecordTime).TotalMinutes} min ago): {{{currentPosition.Coordinates.Longitude}, " +
               $"{currentPosition.Coordinates.Latitude}}}, " +
               $"Full of {double.Round(CurrentLoadKg/MaxLoadKg*100, 2)}% ," +
               $"Type: Container Ship" +
               $"\n Containers:\n    {string.Join("\n    ", Containers)}\n";
    }
    
    public void AddContainer(Container newContainer)
    {
        if (CurrentLoadKg + newContainer.MassKg > MaxLoadKg)
        {
            throw new ShipOverloadingException(
                "The container cannot be added, the ship is full");
        }
        
        Containers.Add(newContainer);
        CurrentLoadKg += newContainer.MassKg;
    }
    
    public void RemoveContainer(Guid containerId)
    {
        var container = GetContainerById(containerId);
        
        if (Containers.Count < 1)
        {
            throw new InvalidOperationException("The container cannot be removed, the ship is empty");
        }
        
        Containers.Remove(container);
        CurrentLoadKg -= container.MassKg;
    }
    
    public Container GetContainerById(Guid containerId)
    {
        return Containers.FirstOrDefault(container => container.Id == containerId, null) ?? throw new InvalidContainerIdException("The container with the given ID does not exist");
    }
    
}