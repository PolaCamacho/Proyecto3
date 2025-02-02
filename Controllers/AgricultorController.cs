namespace ACooperativa.Controllers
{
    using ACooperativa.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using ACooperativa.Data;

    [ApiController]
    [Route("api/[controller]")]
    public class AgricultorController : ControllerBase
    {
        private readonly CooperativaContext _context;

        public AgricultorController(CooperativaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var agricultores = _context.Agricultores.ToList();
            return Ok(agricultores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var agricultor = _context.Agricultores.Find(id);
            if (agricultor == null) return NotFound();
            return Ok(agricultor);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Agricultor agricultor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Agricultores.Add(agricultor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = agricultor.Id }, agricultor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Agricultor agricultor)
        {
            if (id != agricultor.Id) return BadRequest();

            var existingAgricultor = _context.Agricultores.Find(id);
            if (existingAgricultor == null) return NotFound();

            existingAgricultor.Nombre = agricultor.Nombre;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var agricultor = _context.Agricultores.Find(id);
            if (agricultor == null) return NotFound();

            _context.Agricultores.Remove(agricultor);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
