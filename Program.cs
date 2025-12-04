using GestAproAspNet.Data;
using Microsoft.EntityFrameworkCore;
using GestAproAspNet.Services;
using GestAproAspNet.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// ========== DB CONTEXT ==========
builder.Services.AddDbContext<GesApproviDbContext>(options =>
    
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApproviService, ApproviService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IFournisseurService, FournisseurService>();

builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Approvi}/{action=Index}/{id?}");

app.Run();
