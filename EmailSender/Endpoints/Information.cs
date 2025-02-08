namespace EmailSender.Endpoints;

public static class InfoEndpoints
{
    public static void MapInfoEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "it's works!")
            .WithOpenApi();
    }
}