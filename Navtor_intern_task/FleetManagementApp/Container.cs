namespace FleetManagementApp;

public class Container
{
    
    private string Sender { get; }
    private string Addressee { get; }
    private string CargoDescription { get; }
    public double Weight { get; } // in Tons
    public Guid Id { get; }

    public Container(string sender, string addressee, string cargoDescription, double weight)
    {
        Sender = sender;
        Addressee = addressee;
        CargoDescription = cargoDescription;
        Weight = weight;
        Id = Guid.NewGuid();
    }
        
    
    public override string ToString()
    {
        return $"Id: {Id}, " +
               $"Sender: {Sender}, " +
               $"Addressee: {Addressee}, " +
               $"CargoDescription: {CargoDescription}, " +
               $"Weight: {Weight}";
    }
}