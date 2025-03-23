namespace cwic3.Containers;

public abstract class BaseContainer
{
    private static int _counter;

    public BaseContainer(int height, int depth, int maximumPayload)
    {
        Height = height;
        Depth = depth;
        MaximumPayload = maximumPayload;
        SerialNumber = "KON-C-0000";
    }

    public int Mass { set; get; }
    public int TareWeight { set; get; }
    public int CargoWeight { set; get; }
    public int Height { protected set; get; }
    public int Depth { protected set; get; }
    public int MaximumPayload { protected set; get; }
    public string SerialNumber { protected set; get; }

    protected string GenerateSerialNumber(char ConType)
    {
        return "KON-" + ConType.ToString().ToUpper() + "-" + _counter++;
    }

    public abstract void Empty();

    public abstract void Load(int mass);
}