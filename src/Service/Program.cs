using Api;
using Logic.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton<IEmailSender, EmailSender.EmailSender>();
builder.Services.AddSingleton<IPersistence, Persistence.Persistence>();
builder.Services.AddSingleton<ILogic, Logic.Logic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<BddService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();