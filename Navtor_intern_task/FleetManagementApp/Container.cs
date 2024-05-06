namespace FleetManagementApp;

public record Container(string Sender, string Addressee, string CargoDescription, int Weight, Guid Id = default)
{
    public Container(string sender, string addressee, string cargoDescription, int weight)
        : this(sender, addressee, cargoDescription, weight, Guid.NewGuid())
    {
    }
}