using cwic3;
using cwic3.Containers;

var l = new LiquidContainer(100, 100, 100,200);
var g = new GasContainer(100, 100, 100,200);
var c = new RefrigeratedContainer(100, 100, 100,200, 12);

var banana = new Product("banana", 10);

l.Hazardous = true;
l.Load(60);
Console.WriteLine("\n" + l);

g.Load(100);
Console.WriteLine("\n" + g);

c.Load(60, banana);
Console.WriteLine("\n" + c);

var c1 = new RefrigeratedContainer(100, 100, 100,200, 12);
c.Load(40, banana);

var ship = new Ship(100, 10, 10);

Console.WriteLine("\n" + ship);

ship.Load(l);
Console.WriteLine("\nLoaded");
Console.WriteLine(ship);

ship.Load([g, c]);
Console.WriteLine("\nLoaded");
Console.WriteLine(ship);

ship.Remove(g);
Console.WriteLine("\nRemoved");
Console.WriteLine(ship);

ship.Load(g);
Console.WriteLine("\nLoaded");
Console.WriteLine(ship);

Console.WriteLine("\nUnloaded");
Console.WriteLine(ship);

ship.Replace(l.SerialNumber, c1);
Console.WriteLine("\nReplaced");
Console.WriteLine(ship);

var ship1 = new Ship(1, 2, 10);

ship.Transfer(ship1,g);
Console.WriteLine("\nTransferred");
Console.WriteLine(ship);
Console.WriteLine(ship1);

Console.WriteLine("\n\n\n\n");

Console.WriteLine(g + "\n");
Console.WriteLine(ship);