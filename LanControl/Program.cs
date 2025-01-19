using LanControl.Components.Layout;
using LanControl.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCore();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(x => x.IdleTimeout = TimeSpan.FromDays(1));

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.UseSession();
app.UseAntiforgery();
app.UseStaticFiles();
app.MapRazorComponents<AppLayout>()
    .AddInteractiveServerRenderMode();
    
await app.RunAsync();
