
using AutoMapper;
using BussinesLogicLibrary;
using BussinesLogicLibrary.Mappers;
using DataAccessLibrary;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("DBConnection");

builder.Services.AddDbContext<BI_TESTGENContext>(options => options.UseSqlServer(connString));

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingSetup());
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<BI_TESTGENContext>();

builder.Services.AddTransient<IPersonaService, PersonaService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Host.UseSerilog((ctx, lc) =>
//    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

// Configurando política CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        b => b.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//Agregando la política creada para que sea utilizada por la apliación.
app.UseCors("AlloAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
