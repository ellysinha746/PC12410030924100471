using TallerMecanico.ClassLibrary.Core.Entities;

namespace TallerMecanico.ClassLibrary.Core.Interfaces
{
    public interface IOrdenServicioRepository
    {
        Task<IEnumerable<OrdenServicio>> GetTodasAsync();
        Task<OrdenServicio> GetPorIdAsync(int id);
        Task AgregarAsync(OrdenServicio ordenServicio);
        Task ActualizarAsync(OrdenServicio ordenServicio);
        Task EliminarAsync(int id);
    }
}