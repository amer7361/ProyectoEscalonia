using LaEscalonia.Models;
using LaEscalonia.Repository;
using LaEscalonia.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Configuracion Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
//Configuracion de la base de datos
builder.Services.AddDbContext<EscaloniaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Escalonia"), 
        option => option.EnableRetryOnFailure());

});
builder.Services.AddTransient(typeof(IRepositoryAsync<>),typeof(RepositoryAsync<>));
builder.Services.AddTransient<IUserService,UserService>();
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
