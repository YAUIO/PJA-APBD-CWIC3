using cwic3.Exceptions;

namespace cwic3.Containers;

public class RefrigeratedContainer(int height, int depth, int maximumPayload, double temperature)
    : BaseContainer(height, depth, maximumPayload)
{
    public Product? StoredType { set; get; }
    public double Temperature { set; get; } = temperature;

    public override void Empty()
    {
        Mass = TareWeight;
        CargoWeight = 0;
    }

    public override void Load(int mass)
    {
        throw new NotSupportedException("Not supported for refrigerated container");
    }

    public void Load(int mass, Product type)
    {
        if (mass > MaximumPayload) throw new OverfillException("Cannot exceed Maximum Payload");
        if (StoredType == null) StoredType = type;
        if (!StoredType.Id.Equals(type.Id)) throw new ProductTypeMismatchException(StoredType, type);
        if (Temperature < type.Temperature) throw new TemperatureUnsuitableException(StoredType.Temperature, type.Temperature);
        
        CargoWeight = mass;
        Mass = mass;
    }
}