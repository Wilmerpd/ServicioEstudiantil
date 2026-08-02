using ServicioEstudiantil.Client.Extensions;
using ServicioEstudiantil.Client.Contracts;
using ServicioEstudiantil.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using ServicioEstudiantil.Client.Auth;


var builder = WebApplication.CreateBuilder(args);

// 1. Registro de los componentes base de Blazor para .NET 8
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Registro del HttpClient base con Bypass de SSL para desarrollo
builder.Services.AddScoped(sp =>
{
    var handler = new HttpClientHandler
    {
        // Esto le dice a .NET: "Confía en cualquier certificado local, déjame pasar"
        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
    };

    // Apuntamos directo al puerto seguro de tu API
    return new HttpClient(handler) { BaseAddress = new Uri("https://localhost:7097/") };
});

// 3. Registro de las extensiones (Las clases de la foto del profesor)
builder.Services.AddScoped<HttpClientService>();
builder.Services.AddScoped<LocalStorageService>();


// 4. Registro de los contratos y servicios de la capa de aplicación
builder.Services.AddScoped<IAsignaturaService, AsignaturaService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<EstudianteService>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IHorarioService, HorarioService>();
builder.Services.AddScoped<ITitulacionService, TitulacionService>();
builder.Services.AddScoped<IAsignaturaService, AsignaturaService>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();
builder.Services.AddScoped<ICalificacionService, CalificacionService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
})
.AddCookie("Cookies", options =>
{
    // Aquí le decimos a .NET dónde está realmente nuestro Login
    options.LoginPath = "/login";
});

builder.Services.AddAuthorization();

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