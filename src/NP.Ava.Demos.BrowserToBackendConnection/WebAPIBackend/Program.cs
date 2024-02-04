using Microsoft.Extensions.Hosting;
using WebAPIBackend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string PolicyName = "CorsPolicy";

//builder.WebHost.ConfigureKestrel((context, serverOptions) =>
//{
//    var kestrelSection = context.Configuration.GetSection("Kestrel");

//    serverOptions.Configure(kestrelSection)
//        .Endpoint("HTTPS", listenOptions =>
//        {

//        });
//});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddCors
(
    options =>
    {
        options.AddPolicy
        (
            PolicyName,
            builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }
        );
    }
);

builder.Services.AddWindowsService();
//builder.Services.AddHostedService<SimpleService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseCors(PolicyName);

//app.UseAuthorization();
//app.Urls.Add("http://localhost:7168");
app.MapControllers();
//app.MapRazorPages();

app.Run();
