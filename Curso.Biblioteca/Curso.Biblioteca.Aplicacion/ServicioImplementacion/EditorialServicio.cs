using AdministracionEditorials.Infraestructura.RepositorioImplementacion;
using AdministracionPagos.Aplicacion.Dtos;
using AdministracionPagos.Aplicacion.ServicioDefinicion;
using AdministracionPagos.Dominio.RepositorioDefinicion;
using Curso.Biblioteca.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionPagos.Aplicacion.ServicioImplementacion
{
    public class EditorialServicio : IEditorialServicio
    {
        private readonly IEditorialRepositorio editorialRepositorio;

        public EditorialServicio(IEditorialRepositorio editorialRepositorio)
        {
            this.editorialRepositorio = editorialRepositorio;
        }

        public async Task<bool> CreateAsync(CrearEditorialDto EditorialDto)
        {
            var Editorial = new Editorial { 
                Nombre = EditorialDto.Nombre,
                Direccion = EditorialDto.Direccion,

            };
            await editorialRepositorio.CreateAsync(Editorial);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = editorialRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var editorial = consulta.SingleOrDefault();

            await editorialRepositorio.DeleteAsync(editorial);
            return true;
        }

        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
            var consulta = editorialRepositorio.GetAll();
            var listaEditoriales = await consulta.Select( x => new EditorialDto
            {
                Id= x.Id,
                Nombre = x.Nombre,
                Direccion = x.Direccion,
            }).ToListAsync();

            return listaEditoriales;
        }

        public async Task<EditorialDto> GetByIdAsync(int id)
        {
            var consulta = editorialRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var editorial = await consulta.Select(x => new EditorialDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Direccion = x.Direccion,
            }).SingleOrDefaultAsync();

            return editorial;
        }

        public async Task<bool> UpdateAsync(int id, CrearEditorialDto EditorialDto)
        {
            var consulta = editorialRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var editorial = consulta.SingleOrDefault();

            //Establecer los nuevos valores
            editorial.Nombre = EditorialDto.Nombre;
            editorial.Direccion = EditorialDto.Direccion;

            await editorialRepositorio.UpdateAsync(editorial);
            return true;
        }
    }
}
