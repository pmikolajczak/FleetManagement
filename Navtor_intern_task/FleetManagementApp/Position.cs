namespace FleetManagementApp;

public record Position(Tuple<double, double> ActualCoordinate, DateTime UpdateTime)
{
    public Position(Tuple<double, double> actualCoordinate) : this(actualCoordinate, DateTime.Now)
    {
    }
}