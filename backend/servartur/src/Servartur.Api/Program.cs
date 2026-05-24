var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.UseHttpsRedirection();

app.MapGet("/hello", () =>
{
    return "Hello, Kinga! Greeting from Raspberry Pi!";
})
.WithName("GetHello");

app.Run();
