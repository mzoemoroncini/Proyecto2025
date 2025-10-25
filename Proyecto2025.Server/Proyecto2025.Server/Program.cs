using EstudioJuridico.BD.Datos.Entity;
using EstudioJuridico.Repositorio.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto2025.Server.Client.Pages;
using Proyecto2025.Server.Components;


var builder = WebApplication.CreateBuilder(args);
#region configura el constructor de la aplicacion y sus servicios

//builder.Services.AddScoped(sp =>
//    new HttpClient { BaseAddress = new Uri("https://localhost:7206") });
//builder.Services.AddScoped<IHttpServicio, HttpServicio>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();



//conexión bd
var connectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
?? throw new InvalidOperationException(
                    "El string de conexion no existe");
builder.Services.AddDbContext<AppDBContext>(options =>
                                            options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICasoRepositorio, CasoRepositorio>();
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
builder.Services.AddScoped<ITipoDocumentacionRepositorio, TipoDocumentacionRepositorio>();
builder.Services.AddScoped<IDocumentacionRepositorio, DocumentacionRepositorio>();

builder.Services.AddScoped<ICasoPersonaRepositorio, CasoPersonaRepositorio>();



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddServerSideBlazor()
      .AddCircuitOptions(options => { options.DetailedErrors = true; });


#endregion

var app = builder.Build();
#region Construcción de la aplicacion y el área de middlewears

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
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