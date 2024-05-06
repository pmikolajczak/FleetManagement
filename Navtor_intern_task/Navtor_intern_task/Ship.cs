namespace Navtor_intern_task;

public class Ship(string id, string name, int width, int length, Tuple<double, double> actualCoordinate)
{
    private string Id { get; } = id;
    private string Name { get; set; } = name;
    private int Width { get; set; } = width;
    private int Length { get; set; } = length;
    private Tuple <double, double> ActualCoordinate { get; set; } = actualCoordinate;

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType()!= obj.GetType())
            return false;

        var other = (Ship)obj;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Width: {Width}, Length: {Length}, ActualCoordinate: {ActualCoordinate}";
    }
    
}