


using MailService;
using Microsoft.EntityFrameworkCore;
using UserMapService;
using Ward.Application;
using Ward.Persistent;
using GOVInforService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigurePersistenceRegister(builder.Configuration);
builder.Services.ConfigurateApplicationService();
builder.Services.ConfigGOVInforService(builder.Configuration);
builder.Services.ConfigUserMapService(builder.Configuration);
builder.Services.ConfigMailService(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConnections();
builder.Services.AddCors(op => op.AddPolicy(name: "angularApp", policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    policy.SetIsOriginAllowedToAllowWildcardSubdomains();
}));
var app = builder.Build();
// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<WardMapContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("angularApp");
app.MapControllers();

app.Run();
