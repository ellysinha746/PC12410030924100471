using Microsoft.EntityFrameworkCore;
using TallerMecanico.ClassLibrary.Core.Entities;
using TallerMecanico.ClassLibrary.Core.Interfaces;

namespace TallerMecanico.ClassLibrary.Infraestructure.Repositories
{
    public class OrdenServicioRepository : IOrdenServicioRepository
    {
        private readonly TallerMecanicoContext _context;

        public OrdenServicioRepository(TallerMecanicoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrdenServicio>> GetTodasAsync()
        {
            return await _context.OrdenServicio.ToListAsync();
        }

        public async Task<OrdenServicio> GetPorIdAsync(int id)
        {
            return await _context.OrdenServicio.FindAsync(id);
        }

        public async Task AgregarAsync(OrdenServicio ordenServicio)
        {
            _context.OrdenServicio.Add(ordenServicio);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(OrdenServicio ordenServicio)
        {
            _context.Entry(ordenServicio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var orden = await _context.OrdenServicio.FindAsync(id);
            if (orden != null)
            {
                _context.OrdenServicio.Remove(orden);
                await _context.SaveChangesAsync();
            }
        }
    }
}
