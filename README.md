# Semana 7 - API con Clean Architecture

API de productos desarrollada con ASP.NET Core y organizada en capas:

- `Semana07Hugo.Domain`: entidades y reglas del dominio.
- `Semana07Hugo.Application`: casos de uso y contratos de persistencia.
- `Semana07Hugo.Infrastructure`: implementaciones de infraestructura; actualmente usa un repositorio en memoria.
- `Semana07Hugo`: API, controladores, DTOs y middleware.

Las dependencias apuntan hacia el dominio: Application define el contrato que Infrastructure implementa, y la API conecta las capas en el punto de entrada.

## Ejecutar

Desde la raíz del repositorio:

```powershell
dotnet restore .\Semana07Hugo.sln
dotnet run --project .\Semana07Hugo\Semana07Hugo.csproj
```

La documentación Swagger se habilita en el entorno `Development`. Las rutas de la API requieren el encabezado `Role: Admin`.

## Crear un producto

`POST /api/products`

```json
{
  "name": "Teclado",
  "price": 25.50,
  "description": "USB"
}
```

Los productos se guardan en memoria y se pierden al reiniciar la aplicación.
