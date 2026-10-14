namespace Semana07Hugo.Application.Products.CreateProduct;

public sealed record CreateProductCommand(string Name, decimal? Price, string? Description);
