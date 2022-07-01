using AdministracionPagos.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionPagos.Aplicacion.ServicioDefinicion
{
    public interface IEditorialServicio
    {
        //GetAll
        Task<ICollection<EditorialDto>> GetAllAsync();

        //GetById
        Task<EditorialDto> GetByIdAsync(int id);

        //Create
        Task<bool> CreateAsync(CrearEditorialDto editorial);

        //Update
        Task<bool> UpdateAsync(int id, CrearEditorialDto editorial);

        //Delete
        Task<bool> DeleteAsync(int id);
    }
}
