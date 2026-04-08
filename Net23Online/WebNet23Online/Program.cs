using WebNet23Online.Models.Maks_Korz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IAuthorization, Authorization>();//мое
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
/*builder.Services.AddScoped<IAnimeGirlGenerator, AnimeGirlGenerator>();
builder.Services.AddScoped<IEpicMeanlessPhraseGenerator, EpicMeanlessPhraseGenerator>();
builder.Services.AddScoped<IRandomBuilder, RandomBuilder>();

builder.Services.AddSingleton<IMazeBuilder, MazeBuilder>();
builder.Services.AddSingleton<IMazeService, MazeService>();*/



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
