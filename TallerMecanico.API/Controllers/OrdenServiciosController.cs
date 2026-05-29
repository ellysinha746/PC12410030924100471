using Microsoft.AspNetCore.Mvc;
using TallerMecanico.ClassLibrary.Core.Entities;
using TallerMecanico.ClassLibrary.Core.Interfaces;

namespace TallerMecanico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenServiciosController : ControllerBase
    {
        private readonly IOrdenServicioRepository _repository;

        // Inyección de dependencias usando la interfaz
        public OrdenServiciosController(IOrdenServicioRepository repository)
        {
            _repository = repository;
        }

        // GET: api/OrdenServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenServicio>>> Get()
        {
            var ordenes = await _repository.GetTodasAsync();
            return Ok(ordenes);
        }

        // GET: api/OrdenServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenServicio>> Get(int id)
        {
            var orden = await _repository.GetPorIdAsync(id);
            if (orden == null) return NotFound();
            return Ok(orden);
        }

        // POST: api/OrdenServicios
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrdenServicio ordenServicio)
        {
            await _repository.AgregarAsync(ordenServicio);
            return CreatedAtAction(nameof(Get), new { id = ordenServicio.Id }, ordenServicio);
        }

        // PUT: api/OrdenServicios/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OrdenServicio ordenServicio)
        {
            if (id != ordenServicio.Id) return BadRequest();
            await _repository.ActualizarAsync(ordenServicio);
            return NoContent();
        }

        // DELETE: api/OrdenServicios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.EliminarAsync(id);
            return NoContent();
        }
    }
}