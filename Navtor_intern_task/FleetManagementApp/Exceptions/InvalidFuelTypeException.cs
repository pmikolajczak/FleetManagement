namespace FleetManagementApp.Exceptions;

public class InvalidFuelTypeException : Exception
{
    public InvalidFuelTypeException(string message) : base(message)
    {
        Console.WriteLine(message);
    }
}