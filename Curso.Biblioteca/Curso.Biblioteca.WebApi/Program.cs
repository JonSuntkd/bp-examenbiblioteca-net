using AdministracionAutors.Infraestructura.RepositorioImplementacion;
using AdministracionEditorials.Infraestructura.RepositorioImplementacion;
using AdministracionLibros.Infraestructura.Contexto;
using AdministracionLibros.Infraestructura.RepositorioImplementacion;
using AdministracionPagos.Aplicacion.ServicioDefinicion;
using AdministracionPagos.Aplicacion.ServicioImplementacion;
using AdministracionPagos.Dominio.RepositorioDefinicion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Inyectar la conexion a base de datos
builder.Services.AddDbContext<AdministracionLibrosContexto>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IAutorRepositorio, AutorRepositorio>();
builder.Services.AddTransient<IAutorServicio, AutorServicio>();

builder.Services.AddTransient<IEditorialRepositorio, EditorialRepositorio>();
builder.Services.AddTransient<IEditorialServicio, EditorialServicio>();

builder.Services.AddTransient<ILibroRepositorio, LibroRepositorio>();
builder.Services.AddTransient<ILibroServicio, LibroServicio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
