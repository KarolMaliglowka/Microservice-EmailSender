using EmailSender.Endpoints;
using EmailSender.Services;
using EmailSender.Settings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmailSender, EmailSender.Services.EmailSender>();
builder.Services.AddSingleton<MessageSender>();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

try
{
    var app = builder.Build();
    app.UseSerilogRequestLogging();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapInfoEndpoints();
    app.MapMailEndpoints();

    app.Run();
    return 0;
}
catch (Exception e)
{
    Log.Fatal(e, "Unhandled exception");
    return 1;
}
finally
{
    await Log.CloseAndFlushAsync();
}