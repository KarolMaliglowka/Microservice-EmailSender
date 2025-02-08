namespace EmailSender.Endpoints;

public static class Information
{
    public static void InfoEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "it's works!")
            .WithOpenApi();
    }
}