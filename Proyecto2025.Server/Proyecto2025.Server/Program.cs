using Microsoft.Extensions.DependencyInjection;
using Proyecto2025.BD.Datos;
using Proyecto2025.Server.Client.Pages;
using Proyecto2025.Server.Components;
using Microsoft.EntityFrameworkCore;



//Constructor de la aplicacion
#region configura el constructor de la aplicacion y sus servicios
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var conectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
?? throw new InvalidOperationException(
                    "El string de conexion no existe");
builder.Services.AddDbContext<AppDBContext>(Options => 
                                            Options.UseSqlServer(conectionString));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

#endregion

//CONSTRUCCION DE LA APLICACION
var app = builder.Build();

#region Construcción de la aplicacion y el área de middlewears

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Proyecto2025.Server.Client._Imports).Assembly);
app.MapControllers();

#endregion
app.Run();
