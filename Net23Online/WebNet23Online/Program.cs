using MazeCore;
using MazeCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data;
using WebNet23Online.Data.Repositories;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Services;
using WebNet23Online.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebNet23Online;Integrated Security=True;Connect Timeout=30;";
builder.Services.AddDbContext<WebContext>(op => op.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ILittleLemonMenuService, LittleLemonMenuService>();
builder.Services.AddScoped<ILittleLemonTestimonialService, LittleLemonTestimonialService>();
builder.Services.AddScoped<ILittleLemonSubscribeService, LittleLemonSubscribeService>();
// Register Services
//builder.Services.AddScoped<IAnimeGirlGenerator, AnimeGirlGenerator>(diContainer =>
//{
//    var randomBuilderAAAA = diContainer.GetService<IRandomBuilder>(); // 24
//    var epicMeanlessPhraseGenerator = diContainer.GetService<IEpicMeanlessPhraseGenerator>(); // 17
//    var animeGirlGenerator = new AnimeGirlGenerator(epicMeanlessPhraseGenerator, randomBuilderAAAA);

//    return animeGirlGenerator;
//});
//builder.Services.AddScoped<IEpicMeanlessPhraseGenerator, EpicMeanlessPhraseGenerator>(diContainer =>
//{
//    var randomBuilderBBBB = diContainer.GetService<IRandomBuilder>(); // 24
//    var epicMeanlessPhraseGenerator = new EpicMeanlessPhraseGenerator(randomBuilderBBBB);
//    return epicMeanlessPhraseGenerator;
//});

//builder.Services.AddScoped<IRandomBuilder, RandomBuilder>(diContainer =>
//{
//    var randomBuilder = new RandomBuilder();
//    return randomBuilder;
//});
//builder.Services.AddTransient<IRandomBuilder, RandomBuilder>(); // One for each Call
//builder.Services.AddScoped<IRandomBuilder, RandomBuilder>();    // One for each Request (user)
//builder.Services.AddSingleton<IRandomBuilder, RandomBuilder>(); // One.

//             Life Time
// Transient < Scoped < Singleton

builder.Services.AddScoped<IAnimeGirlGenerator, AnimeGirlGenerator>();
builder.Services.AddScoped<IEpicMeanlessPhraseGenerator, EpicMeanlessPhraseGenerator>();
builder.Services.AddScoped<IRandomBuilder, RandomBuilder>();

builder.Services.AddSingleton<IMazeBuilder, MazeBuilder>();
builder.Services.AddSingleton<IMazeService, MazeService>();
builder.Services.AddScoped<IAnimalWorldService, AnimalWorldService>();
builder.Services.AddScoped<IRockBandsService, RockBandsService>();

builder.Services.AddSingleton<IRockLegendsPick, RockLegendsPick>();

builder.Services.AddScoped<ICatalogService, CatalogService>();

//DelightBistro DI
builder.Services.AddSingleton<IFoodItemGenerator, FoodItemGenerator>();
builder.Services.AddSingleton<IMenuTypeGenerator, MenuTypeGenerator>();

//HabitTracker DI
builder.Services.AddScoped<IHabitTrackerService, HabitTrackerService>();
builder.Services.AddScoped<IHabitStatisticsService, HabitStatisticsService>();

//JapaneseDomesticMarker DI
builder.Services.AddSingleton<IJapaneseDomesticMarketGenerator, JapaneseDomesticMarketGenerator>();
builder.Services.AddSingleton<IJDMCatalogGenerator, JDMCatalogGenerator>();

// Repositories
builder.Services.AddScoped<IAnimeGirlRepository, AnimeGirlRepository>();
builder.Services.AddScoped<IMazeRepository, MazeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
