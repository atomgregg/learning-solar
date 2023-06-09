var builder = WebApplication.CreateBuilder(args);

// add controllers
builder.Services.AddControllers();

// add Swagger/OpenAPI (ref: https://aka.ms/aspnetcore/swashbuckle)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

// allow the vue application to access the API
var allowedSpecificOrigins = "_allowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: allowedSpecificOrigins,
        policy =>
        {
            policy
                .WithOrigins(
                    "http://localhost:3000",
                    "http://pi01.fritz.box:81",
                    "http://atomgregg.v6.rocks",
                    "https://atomgregg.v6.rocks"
                )
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowedSpecificOrigins);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
