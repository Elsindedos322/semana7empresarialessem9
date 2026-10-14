using Semana07Hugo.Domain.Entities;

namespace Semana07Hugo.Application.Abstractions;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken = default);
}
