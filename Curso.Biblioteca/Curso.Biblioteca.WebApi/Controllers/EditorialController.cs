using AdministracionPagos.Aplicacion.Dtos;
using AdministracionPagos.Aplicacion.ServicioDefinicion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionPagos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase, IEditorialServicio
    {
        private readonly IEditorialServicio editorialServicio;

        public EditorialController(IEditorialServicio editorialServicio)
        {
            this.editorialServicio = editorialServicio;
        }

        [HttpPost]
        public async Task<bool> CreateAsync(CrearEditorialDto editorial)
        {
            return await editorialServicio.CreateAsync(editorial);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            return await editorialServicio.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
            return await editorialServicio.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<EditorialDto> GetByIdAsync(int id)
        {
            return await editorialServicio.GetByIdAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(int id, CrearEditorialDto clientoDto)
        {
            return await editorialServicio.UpdateAsync(id, clientoDto);
        }
    }
}
