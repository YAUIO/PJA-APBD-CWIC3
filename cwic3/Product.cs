namespace cwic3;

public record Product
{
    private static int _counter;
    public int Id { get; }
    public required string Name { set; get; }
    public required double Temperature { set; get; }

    public Product()
    {
        Id = _counter++;
    }
}