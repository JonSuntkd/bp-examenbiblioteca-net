using AdministracionLibros.Infraestructura.Contexto;
using AdministracionPagos.Dominio.RepositorioDefinicion;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionLibros.Infraestructura.RepositorioImplementacion
{
    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly AdministracionLibrosContexto contexto;

        public LibroRepositorio(AdministracionLibrosContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task CreateAsync(Libro libro)
        {
            await contexto.AddAsync(libro);
            await contexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(Libro libro)
        {
            contexto.Remove(libro);
            await contexto.SaveChangesAsync();
        }

        public IQueryable<Libro> GetAll()
        {
            return contexto.Libros.AsQueryable();
        }

        public async Task UpdateAsync(Libro Libro)
        {
            contexto.Update(Libro);
            await contexto.SaveChangesAsync();
        }
    }
}
