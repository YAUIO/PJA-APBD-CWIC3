using cwic3.Exceptions;

namespace cwic3.Containers;

public class LiquidContainer : BaseContainer, IHazardNotifier
{
    public LiquidContainer(int height, int depth, int maximumPayload) : base(height, depth, maximumPayload)
    {
    }

    protected override char ConType { get; } = 'L';
    public bool Hazardous { set; get; }

    public void Notify()
    {
        Notify("");
    }

    public void Notify(string msg)
    {
        Console.WriteLine("Hazardous situation occured! " + msg + " Affected liquid container: " + SerialNumber);
    }

    public override void Load(int mass)
    {
        if (Hazardous && mass > MaximumPayload / 2)
            Notify("Loading more than 50% of maximal capacity with hazardous material.");
        else if (mass > MaximumPayload * 0.9) Notify("Loading more than 90% of maximal capacity with liquid.");

        base.Load(mass);
    }
    
    public override string ToString()
    {
        return base.ToString() + "\n" +
               "Hazardous: " + Hazardous;
    }
}