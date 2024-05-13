using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using dyplom.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<dyplomContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dyplomContext") ?? throw new InvalidOperationException("Connection string 'dyplomContext' not found.")));
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".MyApp.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10); // ������������ ���� ���������� ��� ���
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
