using AdministracionPagos.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionPagos.Aplicacion.ServicioDefinicion
{
    public interface ILibroServicio
    {
        //GetAll
        Task<ICollection<LibroDto>> GetAllAsync();

        //GetById
        Task<LibroDto> GetByIdAsync(int id);

        //Create
        Task<bool> CreateAsync(CrearLibroDto libro);

        //Update
        Task<bool> UpdateAsync(int id, CrearLibroDto libroDto);

        //Delete
        Task<bool> DeleteAsync(int id);
    }
}
