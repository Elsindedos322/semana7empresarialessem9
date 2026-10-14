using Microsoft.OpenApi;
using Semana07Hugo.Application.Abstractions;
using Semana07Hugo.Application.Products.CreateProduct;
using Semana07Hugo.Infrastructure.Persistence;
using Semana07Hugo.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<CreateProductHandler>();
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lab 07 - Middlewares API", Version = "v1" });

    c.AddSecurityDefinition("RoleHeader", new OpenApiSecurityScheme
    {
        Name = "Role",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Escribe 'Admin' para dar permisos de acceso."
    });

    c.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecuritySchemeReference("RoleHeader", document),
            new List<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab 07 API v1");
    });
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseMiddleware<RoleBasedAccessMiddleware>();

app.UseMiddleware<ParameterValidationMiddleware>();

app.MapControllers();

app.Run();