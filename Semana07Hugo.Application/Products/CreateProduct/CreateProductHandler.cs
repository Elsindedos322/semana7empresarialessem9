using Semana07Hugo.Application.Abstractions;
using Semana07Hugo.Domain.Entities;

namespace Semana07Hugo.Application.Products.CreateProduct;

public sealed class CreateProductHandler(IProductRepository productRepository)
{
    public async Task<CreateProductResult> HandleAsync(
        CreateProductCommand command,
        CancellationToken cancellationToken = default)
    {
        var product = new Product(command.Name, command.Price, command.Description);
        await productRepository.AddAsync(product, cancellationToken);

        return new CreateProductResult(product.Name, product.Price, product.Description);
    }
}
