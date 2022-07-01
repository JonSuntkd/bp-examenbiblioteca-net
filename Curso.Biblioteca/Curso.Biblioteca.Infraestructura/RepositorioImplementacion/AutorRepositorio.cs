using AdministracionLibros.Infraestructura.Contexto;
using AdministracionPagos.Dominio.RepositorioDefinicion;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionAutors.Infraestructura.RepositorioImplementacion
{
    public class AutorRepositorio : IAutorRepositorio
    {
        private readonly AdministracionLibrosContexto contexto;


        public AutorRepositorio(AdministracionLibrosContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task CreateAsync(Autor autor)
        {
            await contexto.AddAsync(autor);
            await contexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(Autor autor)
        {
            contexto.Remove(autor);
            await contexto.SaveChangesAsync();
        }

        public IQueryable<Autor> GetAll()
        {
            return contexto.Autores.AsQueryable();
        }

        public async Task UpdateAsync(Autor autor)
        {
            contexto.Update(autor);
            await contexto.SaveChangesAsync();
        }
    }
}
