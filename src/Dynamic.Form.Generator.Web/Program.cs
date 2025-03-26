using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Dynamic.Form.Generator.Web;
using Dynamic.Form.Generator.Web.Components;

using MudBlazor.Services;
using MudBlazor;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass
        = Defaults.Classes.Position.BottomCenter;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
