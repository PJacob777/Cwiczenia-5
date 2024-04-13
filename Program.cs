using API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IMockDb,MockDb>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/GetAnimals", (IMockDb mockDb) =>
{
    return Results.Ok(mockDb.GetAll());
});
app.MapGet("/GetAnimal/{id:int}", (IMockDb mochDb,int id) =>
{
    var animal = mochDb.GetAnimal(id);
    if (animal is null) return Results.NotFound("");
    return Results.Ok(animal);
});
app.MapPost("/animals", (Animal animal, IMockDb iMochDb) =>
{
    iMochDb.AddAnimal(animal);
    return Results.Created();
});
app.MapPut("/Animal/{id:int}", (IMockDb mochDb, Animal animal, int id) =>
{
    var deleted = mochDb.GetAnimal(id);
    if (deleted is null) return Results.NotFound("");
    mochDb.EditAnimal(id, animal);
    return Results.Created();

});
app.MapDelete("/Animal", (Animal animal, IMockDb mockDb) =>
{
    var toDelete = mockDb.GetAnimal(animal.ID);
    if (toDelete is null) return Results.BadRequest();
    mockDb.DeleteAnimal(animal);
    return Results.Ok();
});
app.MapPost("/Visit", (IMockDb mochDb, Visit visit) =>
{
    mochDb.AddVisit(visit);
    return Results.Created();
});
app.MapGet("/GetVisits", (IMockDb mockDb) =>
{
    return Results.Ok(mockDb.GetAllVisits());
});
app.MapControllers();
app.Run();

