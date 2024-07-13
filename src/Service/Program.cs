using Api;
using Logic.Interfaces;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables("BddExample_");

var smtpServerHost = builder.Configuration.GetValue<string>("SmtpServer:Host");
var smtpServerPort = builder.Configuration.GetValue<int>("SmtpServer:Port");
var connectionString = builder.Configuration.GetConnectionString("database");

builder.Services.AddGrpc();
builder.Services.AddSingleton<IEmailSender>(_ => new EmailSender.EmailSender(smtpServerHost, smtpServerPort));
builder.Services.AddSingleton<IPersistence>(_ => new Persistence.Persistence(connectionString));
builder.Services.AddSingleton<ILogic, Logic.Logic>();
builder.Services.AddHostedService<PeriodicClear>();

var app = builder.Build();

app.MapGrpcService<BddService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();