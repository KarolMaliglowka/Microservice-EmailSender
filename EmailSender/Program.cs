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

app.MapGet("/", () => "it's works!")
    .WithOpenApi();

app.MapPost("/sendMail", (EmailContent emailContent, IEmailSender emailSender) =>
    {
        emailSender.SendMail(emailContent);
    })
    .WithName("SendMail")
    .WithOpenApi();

app.MapPost("/sendMailPro", () =>
    {

    })
    .WithName("SendMailPro")
    .WithOpenApi();

app.Run();
