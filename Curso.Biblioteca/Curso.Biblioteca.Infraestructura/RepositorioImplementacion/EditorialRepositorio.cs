using AdministracionLibros.Infraestructura.Contexto;
using AdministracionPagos.Dominio.RepositorioDefinicion;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionEditorials.Infraestructura.RepositorioImplementacion
{
    public class EditorialRepositorio : IEditorialRepositorio
    {
        private readonly AdministracionLibrosContexto contexto;

        public EditorialRepositorio(AdministracionLibrosContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task CreateAsync(Editorial Editorial)
        {
            await contexto.AddAsync(Editorial);
            await contexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(Editorial Editorial)
        {
            contexto.Remove(Editorial);
            await contexto.SaveChangesAsync();
        }

        public IQueryable<Editorial> GetAll()
        {
            return contexto.Editoriales.AsQueryable();
        }

        public async Task UpdateAsync(Editorial Editorial)
        {
            contexto.Update(Editorial);
            await contexto.SaveChangesAsync();
        }
    }
}
