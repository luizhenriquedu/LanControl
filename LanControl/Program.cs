using LanControl.Components.Layout;
using LanControl.Core;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    

builder.Services.AddControllers();
builder.Services.AddCore();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(x => x.IdleTimeout = TimeSpan.FromDays(1));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Error", true);

app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<AppLayout>()
    .AddInteractiveServerRenderMode();

app.UseSession();

app.MapControllers();

await app.RunAsync();