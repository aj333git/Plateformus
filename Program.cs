using Plateformus;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<GymOptions>(options => {
    options.Machine_Name = "Shoulder_Press";
});
var app = builder.Build();
app.UseMiddleware<GymMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
