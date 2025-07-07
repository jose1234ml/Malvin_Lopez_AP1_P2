using Blazored.Toast;
using Malvin_Lopez_AP1_P2.Components;
using Malvin_Lopez_AP1_P2.Components.Dal;
using Malvin_Lopez_AP1_P2.Components.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextFactory<Contexto>(options =>
    options.UseNpgsql(ConStr));

builder.Services.AddScoped<RegistroService>();
builder.Services.AddBlazoredToast();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
