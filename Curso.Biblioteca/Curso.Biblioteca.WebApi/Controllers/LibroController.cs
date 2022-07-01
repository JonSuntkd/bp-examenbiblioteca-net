using AdministracionPagos.Aplicacion.Dtos;
using AdministracionPagos.Aplicacion.ServicioDefinicion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionPagos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase, ILibroServicio
    {
        private readonly ILibroServicio libroServicio;

        public LibroController(ILibroServicio libroServicio)
        {
            this.libroServicio = libroServicio;
        }

        [HttpPost]
        public async Task<bool> CreateAsync(CrearLibroDto libro)
        {
            return await libroServicio.CreateAsync(libro);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            return await libroServicio.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
            return await libroServicio.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<LibroDto> GetByIdAsync(int id)
        {
            return await libroServicio.GetByIdAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(int id, CrearLibroDto clientoDto)
        {
            return await libroServicio.UpdateAsync(id, clientoDto);
        }
    }
}
