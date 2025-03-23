using cwic3.Containers;

namespace cwic3;

public class Ship
{
    private readonly List<BaseContainer> _containers = [];
    public readonly int MaxAmount;

    public readonly double MaxSpeed;
    public readonly double MaxWeight;

    public Ship(double maxWeight, int maxAmount, double maxSpeed)
    {
        MaxWeight = maxWeight;
        MaxAmount = maxAmount;
        MaxSpeed = maxSpeed;
    }

    public void Load(BaseContainer container)
    {
        _containers.Add(container);
    }

    public void Load(List<BaseContainer> containers)
    {
        _containers.AddRange(containers);
    }

    public bool Remove(BaseContainer container)
    {
        return _containers.Remove(container);
    }

    public bool Unload(BaseContainer container)
    {
        return _containers.Remove(container);
    }

    public bool Replace(string serialNumber, BaseContainer replacement)
    {
        BaseContainer? container = null;
        foreach (var bc in _containers)
            if (bc.SerialNumber.Equals(serialNumber))
            {
                container = bc;
                break;
            }

        if (container == null) return false;

        _containers.Insert(_containers.IndexOf(container), replacement);
        return _containers.Remove(container);
    }

    public override string ToString()
    {
        return
            "Ship info: \n" +
            "MaxWeight: " + MaxWeight + " \n" +
            "MaxAmount: " + MaxAmount + " \n" +
            "MaxSpeed: " + MaxSpeed + " \n" +
            "Containers: " + _containers;
    }
}