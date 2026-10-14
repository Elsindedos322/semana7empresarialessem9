using System.Collections.Concurrent;
using Semana07Hugo.Application.Abstractions;
using Semana07Hugo.Domain.Entities;

namespace Semana07Hugo.Infrastructure.Persistence;

public sealed class InMemoryProductRepository : IProductRepository
{
    private readonly ConcurrentQueue<Product> _products = new();

    public Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _products.Enqueue(product);
        return Task.CompletedTask;
    }
}
