var builder = WebApplication.CreateBuilder(args);

//CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; //this name is arbitary

// Add services to the container.
//In ASP.NET Core, services such as the DB context must be registered with the dependency injection (DI) container.
//The container provides the service to controllers.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Calls AddCors with a lambda expression.
//The lambda takes a CorsPolicyBuilder object.
//Configuration options, such as WithOrigins, are described later in this article.
//The AddCors method call adds CORS services to the app's service container
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
//Calls the UseCors extension method and specifies the _myAllowSpecificOrigins CORS policy. UseCors adds the CORS middleware.
//The call to UseCors must be placed after UseRouting, but before UseAuthorization. For more information, see Middleware order.
//Enables the _myAllowSpecificOrigins CORS policy for all controller endpoints. 


app.UseAuthorization();

app.MapControllers();

app.Run();
// In the ConfigureServices method of the Startup class, add the following code:
