using cwic3.CLI;
using cwic3.Containers;

namespace cwic3;

public class Tutorial3
{
    public static void Main(string[] args)
    {
        Test();
        /*Console.WriteLine("Do you want to run test code or CLI interface? (test/cli)");
        var answer = Console.ReadLine();
        if (answer == null || answer.Equals("test"))
        {
            Test();
            return;
        }

        if (!answer.Equals("cli")) throw new Exception("Wrong answer provided");

        while (true) Menu();*/
    }

    private static void Menu()
    {
        Console.WriteLine("Possible commands: " + string.Join(',', Enum.GetNames<Command>()));
        var answer = Console.ReadLine();
        Command command;

        if (answer == null) return;
        if (!Enum.TryParse(answer, out command)) command = Command.Error;


        switch (command)
        {
            case Command.Error: Console.WriteLine("Error"); break;
            case Command.AddShip: ShipManager.Create(); break;
            case Command.SelectShip: ShipManager.Select(); break;
            case Command.RemoveShip: ShipManager.Remove(); break;
            case Command.SelectContainer: ContainerManager.Select(); break;
            case Command.RemoveContainer: ContainerManager.Remove(); break;
            case Command.AddContainer: ContainerManager.Create(); break;
            case Command.Exit: Environment.Exit(0); break;
            
        }
    }

    private static void Test()
    {
        var l = new LiquidContainer(100, 100, 100, 200);
        var g = new GasContainer(100, 100, 100, 200);
        var c = new RefrigeratedContainer(100, 100, 100, 200, 12);

        var banana = new Product("banana", 10);

        l.Hazardous = true;
        l.Load(60);
        Console.WriteLine("\n" + l);

        g.Load(100);
        Console.WriteLine("\n" + g);

        c.Load(60, banana);
        Console.WriteLine("\n" + c);

        var c1 = new RefrigeratedContainer(100, 100, 100, 200, 12);
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

        ship.Transfer(ship1, g);
        Console.WriteLine("\nTransferred");
        Console.WriteLine(ship);
        Console.WriteLine(ship1);

        Console.WriteLine("\n\n\n\n");

        Console.WriteLine(g + "\n");
        Console.WriteLine(ship);
    }

    private enum Command
    {
        AddShip,
        SelectShip,
        RemoveShip,
        AddContainer,
        SelectContainer,
        RemoveContainer,
        Exit,
        Error
    }
}