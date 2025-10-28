using EstudioJuridico.BD.Datos.Entity;
using EstudioJuridico.Repositorio.Repositorios;
using EstudioJuridico.Servicio.ServiciosHttp;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto2025.Server.Client.Pages;
using Proyecto2025.Server.Components;
using Proyecto2025.Servicio.ServiciosHttp;

var builder = WebApplication.CreateBuilder(args);

// HttpClient global (para Blazor Server)
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://localhost:7084") });

// Servicio HTTP personalizado
builder.Services.AddScoped<IHttpServicio, HttpServicio>();

// Swagger
builder.Services.AddSwaggerGen();

// Base de datos
var connectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
    ?? throw new InvalidOperationException("El string de conexión no existe");
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(connectionString));

// Repositorios
builder.Services.AddScoped<ICasoRepositorio, CasoRepositorio>();
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
builder.Services.AddScoped<ITipoDocumentacionRepositorio, TipoDocumentacionRepositorio>();
builder.Services.AddScoped<IDocumentacionRepositorio, DocumentacionRepositorio>();
builder.Services.AddScoped<ICasoPersonaRepositorio, CasoPersonaRepositorio>();

// Blazor y Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });

// --- IMPORTANTE: Desactivamos antiforgery para la API ---
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute());
});

var app = builder.Build();

// Middleware
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

app.MapStaticAssets();

// Primero mapeamos los controladores (API)
app.MapControllers();

// Luego Blazor Server / WASM
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Proyecto2025.Server.Client._Imports).Assembly);

// 💡 Antiforgery va acá, para proteger solo los formularios de Blazor Server
app.UseAntiforgery();

app.Run();
