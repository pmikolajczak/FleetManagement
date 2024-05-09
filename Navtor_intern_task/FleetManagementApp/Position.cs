namespace FleetManagementApp;

public record Position(Tuple<double, double> Coordinates, DateTime UpdateTime)
{
    public Position(Tuple<double, double> coordinates) : this(coordinates, DateTime.Now)
    {
    }
}