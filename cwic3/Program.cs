using cwic3.Containers;

var c = new LiquidContainer(100, 100, 100);
c.Hazardous = true;
c.Load(60);
Console.WriteLine(c.SerialNumber);
var q = new GasContainer(100, 100, 100);
q.Load(100);
Console.WriteLine(q.SerialNumber);