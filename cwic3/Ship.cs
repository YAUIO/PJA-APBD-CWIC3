using System.Text;
using cwic3.Containers;
using cwic3.Exceptions;

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

    private static int GetTotalMass(List<BaseContainer> containers)
    {
        var mass = 0;
        containers.ForEach(c => mass += c.Mass);
        return mass / 1000; //conversion form kg to t
    }

    private double GetTotalMass()
    {
        return GetTotalMass(_containers);
    }

    public void Load(BaseContainer container)
    {
        if (_containers.Count == MaxAmount) throw new OverfillException("Max container capacity reached");
        if (GetTotalMass() + container.Mass > MaxWeight) throw new OverfillException("Loaded mass exceeds max amount");
        _containers.Add(container);
    }

    public void Load(List<BaseContainer> containers)
    {
        foreach (var c in containers) //so we don't need to repeat all check logic here
            Load(c);
    }

    public bool Remove(BaseContainer container)
    {
        return _containers.Remove(container);
    }

    public bool Unload(BaseContainer container)
    {
        if (_containers.Contains(container))
        {
            var ind = _containers.IndexOf(container);
            _containers.Remove(container);
            container.Empty();
            _containers.Insert(ind, container);
            return true;
        }
        else
        {
            return false;
        }
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
        StringBuilder sb = new StringBuilder();
        sb.Append("{ \n");
        foreach (BaseContainer c in _containers)
        {
            sb.Append(c).Append("\n\n");
        }
        if (sb.Length > 0) sb.Remove(sb.Length - 2, 2);
        sb.Append(" }");
        
        return
            "Ship info: \n" +
            "MaxWeight: " + MaxWeight + " \n" +
            "MaxAmount: " + MaxAmount + " \n" +
            "MaxSpeed: " + MaxSpeed + " \n" +
            "Containers: " + sb;
    }
}