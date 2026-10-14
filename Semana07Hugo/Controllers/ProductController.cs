using Microsoft.AspNetCore.Mvc;
using Semana07Hugo.Application.Products.CreateProduct;
using Semana07Hugo.DTOs;

namespace Semana07Hugo.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly CreateProductHandler _createProductHandler;

    public ProductController(CreateProductHandler createProductHandler)
    {
        _createProductHandler = createProductHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(
        [FromBody] CreateProductDto product,
        CancellationToken cancellationToken)
    {
        var result = await _createProductHandler.HandleAsync(
            new CreateProductCommand(product.Name, product.Price, product.Description),
            cancellationToken);

        return Ok(new { message = "Producto creado exitosamente.", data = result });
    }

    [HttpGet("error-test")]
    public IActionResult ForceError()
    {
        throw new Exception("Error de prueba en la base de datos o servidor.");
    }
}