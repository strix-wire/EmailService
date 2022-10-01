var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{

}

app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
