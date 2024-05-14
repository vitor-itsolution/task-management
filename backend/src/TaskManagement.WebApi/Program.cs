using TaskManagement.WebApi.Endpoints;
using TaskManagement.UseCases.Extensions;
using TaskManagement.PostgreSql.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpoints();
builder.Services.AddUseCases();
builder.Services.AddInfraPostgreSql(builder.Configuration);


builder.Services.AddAntiforgery();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication(); // Must be after UseRouting()
app.UseAuthorization(); // Must be after UseAuthentication()
app.UseAntiforgery();

app.MapEndpoints();

app.Run();
