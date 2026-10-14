namespace Semana07Hugo.Domain.Entities;

public sealed class Product
{
    public Product(string name, decimal? price, string? description)
    {
        Name = name;
        Price = price;
        Description = description;
    }

    public string Name { get; }

    public decimal? Price { get; }

    public string? Description { get; }
}
