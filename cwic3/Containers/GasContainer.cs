using cwic3.Exceptions;

namespace cwic3.Containers;

public class GasContainer : BaseContainer, IHazardNotifier
{
    public GasContainer(int height, int depth, int maximumPayload) : base(height, depth, maximumPayload)
    {
    }

    protected override char ConType { get; } = 'G';

    public bool Hazardous { set; get; }

    public void Notify()
    {
        Notify("");
    }

    public void Notify(string msg)
    {
        Console.WriteLine("Hazardous situation occured! " + msg + " Affected gas container: " + SerialNumber);
    }

    public override void Empty()
    {
        var removedMass = (int)(CargoWeight * 0.95);
        Mass -= removedMass;
        CargoWeight -= removedMass;
    }

    public override string ToString()
    {
        return base.ToString() + "\n" +
               "Hazardous: " + Hazardous;
    }
}