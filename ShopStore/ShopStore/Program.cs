using IdentitySample.Repositories;
using Microsoft.EntityFrameworkCore;
using ShopStore.Models.Context;
using ShopStore.Service;
using ShopStore.Service.Interface;
using ShopStore.Settings;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddMvc();
builder.Services.AddTransient<IRegister, RegisterService>();
builder.Services.AddScoped<IMessageSender, MessageSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
