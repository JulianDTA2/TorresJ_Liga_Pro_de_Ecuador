using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TorresJ_Liga_Pro_de_Ecuador.Data;
using TorresJ_Liga_Pro_de_Ecuador.Repos;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TorresJ_Liga_Pro_de_EcuadorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TorresJ_Liga_Pro_de_EcuadorContext") ?? throw new InvalidOperationException("Connection string 'TorresJ_Liga_Pro_de_EcuadorContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
// Program.cs - Add this line before building the app
builder.Services.AddScoped<EquipoRepo>();


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
