using AdministracionPagos.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionPagos.Aplicacion.ServicioDefinicion
{
    public interface IAutorServicio
    {
        //GetAll
        Task<ICollection<AutorDto>> GetAllAsync();

        //GetById
        Task<AutorDto> GetByIdAsync(int id);

        //Create
        Task<bool> CreateAsync(CrearAutorDto autor);

        //Update
        Task<bool> UpdateAsync(int id, CrearAutorDto autorDto);

        //Delete
        Task<bool> DeleteAsync(int id);
    }
}
