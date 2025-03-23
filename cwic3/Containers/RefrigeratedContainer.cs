using cwic3.Exceptions;

namespace cwic3.Containers;

public class RefrigeratedContainer(int height, int depth, int maximumPayload, int tareWeight, double temperature)
    : BaseContainer(height, depth, maximumPayload, tareWeight)
{
    public Product? StoredType { set; get; }
    public double Temperature { set; get; } = temperature;
    protected override char ConType { get; } = 'C';

    public override void Load(int mass)
    {
        throw new NotSupportedException("Not supported for refrigerated container");
    }

    public void Load(int mass, Product type)
    {
        if (StoredType == null) StoredType = type;
        if (!StoredType.Id.Equals(type.Id)) throw new ProductTypeMismatchException(StoredType, type);
        if (Temperature < type.Temperature)
            throw new TemperatureUnsuitableException(Temperature, type.Temperature);

        base.Load(mass);
    }

    public override string ToString()
    {
        return base.ToString() + "\n" +
               "Stored Type: " + StoredType + "\n" +
               "Temperature: " + Temperature;
    }
}