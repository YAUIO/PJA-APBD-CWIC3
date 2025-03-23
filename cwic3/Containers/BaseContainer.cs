using cwic3.Exceptions;

namespace cwic3.Containers;

public abstract class BaseContainer
{
    private static int _counter;
    public readonly int Depth;
    public readonly int Height;
    public readonly int MaximumPayload;

    public readonly string SerialNumber;
    
    public BaseContainer(int height, int depth, int maximumPayload)
    {
        Height = height;
        Depth = depth;
        MaximumPayload = maximumPayload;
        SerialNumber = GenerateSerialNumber();
    }

    public int Mass { set; get; }
    public int TareWeight { set; get; }
    public int CargoWeight { set; get; }
    protected virtual char ConType { get; } = 'B';

    protected string GenerateSerialNumber()
    {
        return "KON-" + ConType.ToString().ToUpper() + "-" + _counter++;
    }

    public virtual void Empty()
    {
        Mass = TareWeight;
        CargoWeight = 0;
    }

    public virtual void Load(int mass)
    {
        if (mass > MaximumPayload) throw new OverfillException("Cannot exceed Maximum Payload");
        CargoWeight = mass;
        Mass = mass + TareWeight;
    }

    public override string ToString()
    {
        return "Container Info: \n" +
               "Depth: " + Depth + "\n" +
               "Height: " + Height + "\n" +
               "Maximum Payload: " + MaximumPayload + "\n" +
               "S/N: " + SerialNumber;
    }
}