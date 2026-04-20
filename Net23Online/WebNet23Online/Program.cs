var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebNet23Online;Integrated Security=True;Connect Timeout=30;";
builder.Services.AddDbContext<WebContext>(op => op.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
