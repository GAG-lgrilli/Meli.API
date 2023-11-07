using Microsoft.EntityFrameworkCore;
using MinimalApiMeli.Entities;
using MinimalApiMeli.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TablesDB>(opt => opt.UseInMemoryDatabase("category")
                                                    .UseInMemoryDatabase("provider")
                                                    .UseInMemoryDatabase("products")
                                                    );
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

#region Category
app.MapGet("/category", async (TablesDB db) =>
    await db.categories.ToListAsync());

app.MapGet("/category/{id}", async (int id, TablesDB db) =>
    await db.categories.Where(x => x.id == id).ToListAsync());

app.MapPost("/category", async (Category category, TablesDB db) =>
{
    db.categories.Add(category);
    await db.SaveChangesAsync();

    return Results.Created($"/category/{category.id}", category);
});

app.MapPut("/category/{id}", async (int id, Category inputEntity, TablesDB db) =>
{
    var category = await db.categories.FindAsync(id);

    if (category is null) return Results.NotFound();

    category.descripcion = inputEntity.descripcion;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/category/{id}", async (int id, TablesDB db) =>
{
    if (await db.categories.FindAsync(id) is Category category)
    {
        db.categories.Remove(category);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});
#endregion

#region Products
app.MapGet("/products", async (TablesDB db) =>
    await db.products.ToListAsync());

app.MapGet("/products/{id}", async (int id, TablesDB db) =>
    await db.products.Where(x => x.id == id).ToListAsync());

app.MapPost("/products", async (Products entity, TablesDB db) =>
{
    db.products.Add(entity);
    await db.SaveChangesAsync();

    return Results.Created($"/entity/{entity.id}", entity);
});

app.MapPut("/products/{id}", async (int id, Products inputEntity, TablesDB db) =>
{
    var entity = await db.products.FindAsync(id);

    if (entity is null) return Results.NotFound();

    entity.description = inputEntity.description;
    entity.price = inputEntity.price;
    entity.quantity = inputEntity.quantity;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/products/{id}", async (int id, TablesDB db) =>
{
    if (await db.products.FindAsync(id) is Products entity)
    {
        db.products.Remove(entity);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});
#endregion

#region Provider
app.MapGet("/provider", async (TablesDB db) =>
    await db.providers.ToListAsync());

app.MapGet("/provider/{id}", async (int id, TablesDB db) =>
    await db.providers.Where(x => x.id == id).ToListAsync());

app.MapPost("/provider", async (Provider entity, TablesDB db) =>
{
    db.providers.Add(entity);
    await db.SaveChangesAsync();

    return Results.Created($"/entity/{entity.id}", entity);
});

app.MapPut("/provider/{id}", async (int id, Provider inputEntity, TablesDB db) =>
{
    var entity = await db.providers.FindAsync(id);

    if (entity is null) return Results.NotFound();

    entity.descripcion = inputEntity.descripcion;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/provider/{id}", async (int id, TablesDB db) =>
{
    if (await db.providers.FindAsync(id) is Provider entity)
    {
        db.providers.Remove(entity);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});
#endregion

app.Run();
