using cwic3.Exceptions;

namespace cwic3.Containers;

public class GasContainer : BaseContainer, IHazardNotifier
{
    public GasContainer(int height, int depth, int maximumPayload) : base(height, depth, maximumPayload)
    {
        SerialNumber = GenerateSerialNumber('G');
    }

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

    public override void Load(int mass)
    {
        if (mass > MaximumPayload) throw new OverfillException("Cannot exceed Maximum Payload");

        CargoWeight = mass;
        Mass = mass;
    }
}