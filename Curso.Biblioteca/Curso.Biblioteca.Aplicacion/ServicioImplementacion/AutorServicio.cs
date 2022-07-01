using AdministracionAutors.Infraestructura.RepositorioImplementacion;
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
    public class AutorServicio : IAutorServicio
    {
        private readonly IAutorRepositorio autorRepositorio;

        public AutorServicio(IAutorRepositorio autorRepositorio)
        {
            this.autorRepositorio = autorRepositorio;
        }

        public async Task<bool> CreateAsync(CrearAutorDto autorDto)
        {
            var autor = new Autor { 
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido
            };
            await autorRepositorio.CreateAsync(autor);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = autorRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var autor = consulta.SingleOrDefault();

            await autorRepositorio.DeleteAsync(autor);
            return true;
        }

        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            var consulta = autorRepositorio.GetAll();
            var listaAutors = await consulta.Select( x => new AutorDto
            {
                Id= x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).ToListAsync();

            return listaAutors;
        }

        public async Task<AutorDto> GetByIdAsync(int id)
        {
            var consulta = autorRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var Autor = await consulta.Select(x => new AutorDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).SingleOrDefaultAsync();

            return Autor;
        }

        public async Task<bool> UpdateAsync(int id, CrearAutorDto AutorDto)
        {
            var consulta = autorRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var Autor = consulta.SingleOrDefault();

            //Establecer los nuevos valores
            Autor.Nombre = AutorDto.Nombre;
            Autor.Apellido = AutorDto.Apellido;

            await autorRepositorio.UpdateAsync(Autor);
            return true;
        }
    }
}
