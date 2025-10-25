using EstudioJuridico.BD.Datos.Entity;
using EstudioJuridico.Repositorio.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto2025.Server.Client.Pages;
using Proyecto2025.Server.Components;



//Constructor de la aplicacion
#region configura el constructor de la aplicacion y sus servicios
var builder = WebApplication.CreateBuilder(args);


var conectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
?? throw new InvalidOperationException(
                    "El string de conexion no existe");
builder.Services.AddDbContext<AppDBContext>(Options => 
                                            Options.UseSqlServer(conectionString));



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddEndpointsApiExplorer(); // necesario para Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "API Proyecto2025", Version = "v1" });
});
builder.Services.AddControllers();


#endregion

//CONSTRUCCION DE LA APLICACION
var app = builder.Build();
app.MapControllers();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Proyecto2025 v1");
        // Si querés que Swagger esté en la raíz:
        // c.RoutePrefix = string.Empty;
    });
}

#endregion
app.Run();



builder.Services.AddScoped<ICasoRepositorio, CasoRepositorio>();
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
builder.Services.AddScoped<ITipoDocumentacionRepositorio, TipoDocumentacionRepositorio>();
builder.Services.AddScoped<IDocumentacionRepositorio, DocumentacionRepositorio>();

builder.Services.AddScoped<ICasoPersonaRepositorio, CasoPersonaRepositorio>();

builder.Services.AddScoped<ITestigosRepositorio, TestigoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();  


