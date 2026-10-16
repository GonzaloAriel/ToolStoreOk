using Ferreteria.Blazor.Components;
using Ferreteria.Blazor.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

    builder.Services.AddHttpClient<ServicioArticulosWeb>(cliente =>
{
    var direccionApi =
        builder.Configuration["ApiBaseUrl"]
        ?? throw new InvalidOperationException(
            "Falta configurar ApiBaseUrl.");

    cliente.BaseAddress = new Uri(direccionApi);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
