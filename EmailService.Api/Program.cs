using EmailSerivce.Application.Commands;
using EmailSerivce.Application.Common.Mappings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel();

//Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ISendEmailService, MimeKitSendMailCommand>();
builder.Services.AddAutoMapper(config =>
{
    //Get information about current assembly in progress
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
});

var app = builder.Build();

//Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{

}

app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
