using LanControl.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCore();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
