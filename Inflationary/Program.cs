using Inflationary.Services;
using Inflationry.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TranslationService>();
builder.Services.AddSingleton<GameManager>();

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
builder =>
{
    builder.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("https://localhost:7011", "https://localhost:44418")
        .AllowCredentials();
}));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
app.UseCors("CorsPolicy");
app.MapHub<GameHub>("/game");

app.Run();
