using EmailSender.Endpoints;
using EmailSender.Services;
using EmailSender.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmailSender, EmailSender.Services.EmailSender>();
builder.Services.AddSingleton<MessageSender>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapInfoEndpoints();
app.MapMailEndpoints();

app.Run();