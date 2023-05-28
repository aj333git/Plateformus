using Plateformus;

//set up the server
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<GymOptions>(options => {
    options.Machine_Name = "Shoulder_Press";
});
//set up the server
var app = builder.Build();
app.UseMiddleware<GymMiddleware>();

//Endpoint, run code against client GET using Lambada
app.MapGet("/", () => "Hello World!");

//run the server
app.Run();
