var builder = WebApplication.CreateBuilder(args);

//CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; //this name is arbitary

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost",
                "http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowedToAllowWildcardSubdomains();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// Below here we add Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins); //Adds CORS middleware, need to follow the order and place this here

app.UseAuthorization();

app.MapControllers();

app.Run();
// In the ConfigureServices method of the Startup class, add the following code:
