using System.Text.RegularExpressions;

namespace FleetManagementApp;

public abstract partial class Ship
{
    public string Id { get; private set; }
    public string Name { get;}
    public int Width { get;} // in meters
    public int Length { get;} // in meters

    public LinkedList<Position> Positions = [];
    
    

    protected Ship(string id, string name, int width, int length, Position currentPosition)
    {
        if(SetId(id) == -1)
        { 
            throw new ArgumentException("The provided ID is not valid. Please provide a valid ID.");
        }
        Width = width;
        Name = name;
        Length = length;
        Positions.AddLast(currentPosition);
    }

    protected Ship(string id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType()!= obj.GetType())
            return false;

        var other = (Ship)obj;
        return Id == other.Id;
    }

    public Position GetCurrentPosition()
    {
        return Positions.Last!.Value;
    }

    public void UpdatePosition(Position newPosition)
    {
        Positions.AddLast(newPosition);
    }


    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    

    private int SetId(string id)
    {
        if (RegexForIdWithImo().IsMatch(id))
        {
            string digits = id.Remove(0, 3);
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

    private static bool CheckImoSum(string digits)
    {
        int sum = 0;
        int multiplier = 7;
        for(int i = 0; i < digits.Length - 1; i++)
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