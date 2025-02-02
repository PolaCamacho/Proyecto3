namespace ACooperativa.Controllers;



    using ACooperativa.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
using ACooperativa.Data;

[ApiController]
    [Route("api/[controller]")]
    public class MaquinariaController : ControllerBase
    {
        private readonly CooperativaContext _context;

        public MaquinariaController(CooperativaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var maquinarias = _context.Maquinarias.ToList();
            return Ok(maquinarias);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var maquinaria = _context.Maquinarias.Find(id);
            if (maquinaria == null) return NotFound();
            return Ok(maquinaria);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Maquinaria maquinaria)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Maquinarias.Add(maquinaria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = maquinaria.Id }, maquinaria);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Maquinaria maquinaria)
        {
            if (id != maquinaria.Id) return BadRequest();

            var existingMaquinaria = _context.Maquinarias.Find(id);
            if (existingMaquinaria == null) return NotFound();

            existingMaquinaria.Nombre = maquinaria.Nombre;
            existingMaquinaria.Descripcion = maquinaria.Descripcion;
            existingMaquinaria.Estado = maquinaria.Estado;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var maquinaria = _context.Maquinarias.Find(id);
            if (maquinaria == null) return NotFound();

            _context.Maquinarias.Remove(maquinaria);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("OrdenadasPorHorasUso")]
        public IActionResult GetMaquinasOrdenadasPorHorasUso()
        {
            // Consulta a la base de datos para obtener las máquinas ordenadas
            var maquinasOrdenadas = _context.Maquinarias
                .OrderByDescending(m => m.HorasDeUso) // Ordena de mayor a menor
                .ToList();

            return Ok(maquinasOrdenadas);
        }


    }


