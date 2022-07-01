using AdministracionPagos.Aplicacion.Dtos;
using AdministracionPagos.Aplicacion.ServicioDefinicion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionPagos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase, IAutorServicio
    {
        private readonly IAutorServicio autorServicio;

        public AutorController(IAutorServicio autorServicio)
        {
            this.autorServicio = autorServicio;
        }

        [HttpPost]
        public async Task<bool> CreateAsync(CrearAutorDto autor)
        {
            return await autorServicio.CreateAsync(autor);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            return await autorServicio.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            return await autorServicio.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<AutorDto> GetByIdAsync(int id)
        {
            return await autorServicio.GetByIdAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(int id, CrearAutorDto clientoDto)
        {
            return await autorServicio.UpdateAsync(id, clientoDto);
        }
    }
}
