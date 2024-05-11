using FleetManagementApp;

var fleet =  new Fleet("Mears");
try{
    var ship1 = new ContainerShip("IMO9356646", "test", 19, 32,1239023,
        new Position(new Coordinates(32.33, 32.1), DateTime.Now));
    
    fleet.AddShip(ship1);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine(fleet);

