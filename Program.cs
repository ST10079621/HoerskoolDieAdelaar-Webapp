using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HoerskoolDieAdelaar.Data;
using HoerskoolDieAdelaar.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HoerskoolDieAdelaarDbContextConnection") ?? throw new InvalidOperationException("Connection string 'HoerskoolDieAdelaarDbContextConnection' not found.");

builder.Services.AddDbContext<HoerskoolDieAdelaarDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<HoerskoolDieAdelaarUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<HoerskoolDieAdelaarDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


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

app.MapRazorPages();


app.Run();


