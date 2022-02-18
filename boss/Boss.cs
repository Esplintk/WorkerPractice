using Microsoft.AspNetCore.Mvc;
using shared;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/enlist", (EnlistRequest enlistRequest, ILogger<Program> logger) =>
{
    logger.LogInformation($"Recieved {enlistRequest}");
    return "This is your token";
})
.WithName("enlist");


app.MapGet("/done", ([FromBody]IToken token , ILogger<Program> logger) =>
{
    logger.LogInformation($"Token {token} has completed its job", token);
})
.WithName("done");



app.MapPost("/start", ([FromBody]string password, ILogger<Program> logger) =>
{
    logger.LogInformation($"Start with {password}", password);
})
.WithName("start");



app.MapGet("/status", (ILogger<Program> logger) =>
{
    logger.LogInformation($"Get of Status");
})
.WithName("status");



app.Run();
