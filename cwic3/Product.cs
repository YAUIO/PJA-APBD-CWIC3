namespace cwic3;

public record Product
{
    private static int _counter;

    public readonly int Id;
    public readonly string Name;
    public readonly double Temperature;

    public Product(string name, double temp)
    {
        Id = _counter++;
        Name = name;
        Temperature = temp;
    }

    public override string ToString()
    {
        return "Product " + Name + ", Temp.Required " + Temperature;
    }
}