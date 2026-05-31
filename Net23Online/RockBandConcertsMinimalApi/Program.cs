using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RockBandConcertsMinimalApi.DbRockBandStuff;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebNet23RockBandConcerts;Integrated Security=True;Connect Timeout=30;";
builder.Services.AddDbContext<MiniDbRockBandContext>(op => op.UseSqlServer(connectionString));

app.MapGet("/", () => "Hello World!");

app.MapGet("GetRockBandConcerts", (MiniDbRockBandContext dbContext) =>
{
    return dbContext.RockBandConcerts.ToList();
});
app.MapPost("AddRockBandConcert", (MiniDbRockBandContext dbContext, [FromBody]RockBandConcert rockBandConcert) =>
{
    dbContext.RockBandConcerts.Add(rockBandConcert);
    dbContext.SaveChanges();
    return rockBandConcert;
});

app.Run();
