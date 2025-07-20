using HTYS.BusinessLayer;
using HTYS.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HTYSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AdresIslem>();
builder.Services.AddScoped<AvukatIslem>();
builder.Services.AddScoped<IcraTakipIslem>();
builder.Services.AddScoped<IhtarIslem>();
builder.Services.AddScoped<LoginIslem>();
builder.Services.AddScoped<MusteriIslem>();
builder.Services.AddScoped<UrunIslem>();

builder.Services.AddScoped<AdresYonetim>();
builder.Services.AddScoped<AvukatYonetim>();
builder.Services.AddScoped<IcraTakipYonetim>();
builder.Services.AddScoped<IhtarYonetim>();
builder.Services.AddScoped<LoginYonetim>();
builder.Services.AddScoped<MusteriYonetim>();
builder.Services.AddScoped<UrunYonetim>();


builder.Services.AddControllersWithViews();


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
