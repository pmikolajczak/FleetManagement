using System.Text.RegularExpressions;

namespace FleetManagementApp;

public abstract partial class Ship
{
    public string? Id { get; private set; }
    public string? Name { get;}
    public int Width { get;}
    public int Length { get;}
    public Tuple<double, double>? ActualCoordinate { get; set; }

    protected Ship(string? id, string? name, int width, int length, Tuple<double, double>? actualCoordinate)
    {
        Id = id;
        Name = name;
        Width = width;
        Length = length;
        ActualCoordinate = actualCoordinate;
    }

    protected Ship()
    {
    }

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

    public int SetId(string? id)
    {
        if (RegexForIdWithImo().IsMatch(id))
        {
            string? digits = id.Remove(0, 3);
            if (!CheckImoSum(digits)) return -1;
            Id = id;
            return 0;
        }
        
        if (RegexForIdWithoutImo().IsMatch(id))
        {
            if (!CheckImoSum(id)) return -1;
            Id = "IMO" + id;
            return 0;
        }
        
        return -1;
    }

    private static bool CheckImoSum(string? digits)
    {
        int sum = 0;
        int multiplier = 7;
        for(int i = 0; i < digits.Length - 2; i++)
        {
            sum += multiplier * int.Parse(digits[i].ToString()) ;
            multiplier--;
        }
        return (sum % 10) == int.Parse(digits[^1].ToString());
    }

    [GeneratedRegex(@"^\d{7}$")]
    private static partial Regex RegexForIdWithoutImo();
    
    [GeneratedRegex(@"^IMO\d{7}$")]
    private static partial Regex RegexForIdWithImo();
}