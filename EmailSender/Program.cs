global using EmailSender.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmailSender, EmailSender.Services.EmailSender>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/sendSimpleMail", () =>
    {

    })
    .WithName("SendSimpleMail")
    .WithOpenApi();

app.Run();
