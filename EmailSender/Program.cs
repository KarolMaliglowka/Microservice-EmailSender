using EmailSender.Dto;
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

app.MapPost("/sendSimpleMail", (EmailContent emailContent, IEmailSender emailSender) =>
    {
        
    })
    .WithName("SendSimpleMail")
    .WithOpenApi();

app.MapPost("/sendMail", () =>
    {

    })
    .WithName("SendMail")
    .WithOpenApi();

app.Run();
