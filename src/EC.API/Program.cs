using EC.API.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppDbContext();
builder.Services.AddCorsPolicies();

builder.Services.AddAuthentication();
builder.Services.AddApplicationServices();

builder.Services.AddPersistenceServices();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("Cors");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
