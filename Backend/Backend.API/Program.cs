using Backend.API.Data;
using Backend.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CardContext>();
builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddTransient<ISetService, SetService>();
builder.Services.AddControllers();
builder.Services.AddCors(options => {
                options.AddDefaultPolicy(builder => {
                    builder.WithOrigins(
                        "http://localhost:3000"
                    ).AllowAnyHeader().AllowAnyMethod();
                });
            });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
