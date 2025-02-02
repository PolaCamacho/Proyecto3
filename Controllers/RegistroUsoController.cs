namespace ACooperativa.Controllers
{
    using ACooperativa.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using ACooperativa.Data;

    [ApiController]
    [Route("api/[controller]")]
    public class RegistroUsoController : ControllerBase
    {
        private readonly CooperativaContext _context;

        public RegistroUsoController(CooperativaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var registros = _context.RegistrosUso.ToList();
            return Ok(registros);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var registro = _context.RegistrosUso.Find(id);
            if (registro == null) return NotFound();
            return Ok(registro);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RegistroUso registro)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.RegistrosUso.Add(registro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = registro.Id }, registro);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RegistroUso registro)
        {
            if (id != registro.Id) return BadRequest();

            var existingRegistro = _context.RegistrosUso.Find(id);
            if (existingRegistro == null) return NotFound();

            existingRegistro.AgricultorId = registro.AgricultorId;
            existingRegistro.MaquinariaId = registro.MaquinariaId;
            existingRegistro.FechaUso = registro.FechaUso;
            existingRegistro.Observaciones = registro.Observaciones;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var registro = _context.RegistrosUso.Find(id);
            if (registro == null) return NotFound();

            _context.RegistrosUso.Remove(registro);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
