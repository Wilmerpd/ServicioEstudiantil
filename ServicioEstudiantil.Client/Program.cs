using ServicioEstudiantil.Client.Extensions;
using ServicioEstudiantil.Client.Contracts;
using ServicioEstudiantil.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Registro de los componentes base de Blazor para .NET 8
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Registro del HttpClient base
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(MyConstant.BaseApiUrl) });

// 3. Registro de las extensiones (Las clases de la foto del profesor)
builder.Services.AddScoped<HttpClientService>();
builder.Services.AddScoped<LocalStorageService>();

// 4. Registro de los contratos y servicios de la capa de aplicación
builder.Services.AddScoped<IAsignaturaService, AsignaturaService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IHorarioService, HorarioService>();
builder.Services.AddScoped<ITitulacionService, TitulacionService>();

var app = builder.Build();

// 5. Configuración del entorno web
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// 6. Mapeo de la aplicación
app.MapRazorComponents<ServicioEstudiantil.Client.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();