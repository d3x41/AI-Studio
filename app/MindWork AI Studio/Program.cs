using System.Reflection;

using AIStudio;
using AIStudio.Components;
using AIStudio.Settings;
using AIStudio.Tools;

using Microsoft.Extensions.FileProviders;

using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 6_000; //milliseconds aka 6 seconds
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Outlined;
});

builder.Services.AddMudMarkdownServices();
builder.Services.AddSingleton<Rust>();
builder.Services.AddMudMarkdownClipboardService<MarkdownClipboardService>();
builder.Services.AddSingleton<SettingsManager>();
builder.Services.AddSingleton<Random>();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddHubOptions(x =>
    {
        x.MaximumReceiveMessageSize = null;
    });

builder.WebHost.UseUrls("http://localhost:5000");

var fileProvider = new ManifestEmbeddedFileProvider(Assembly.GetAssembly(type: typeof(Program))!, "wwwroot");
var app = builder.Build();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = fileProvider,
    RequestPath = string.Empty,
});

app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();