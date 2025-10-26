using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizedScannApi.Domain.Entities;
using OrganizedScannApi.Application.UseCases.Motorcycles;

namespace OrganizedScannApi.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MotorcycleController : ControllerBase
    {
        private readonly MotorcycleService _service;

        public MotorcycleController(MotorcycleService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todas as motocicletas, podendo filtrar por marca e ano.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<Motorcycle>>> GetAll([FromQuery] string? brand, [FromQuery] int? year)
        {
            var motorcycles = await _service.GetAllAsync(brand, year);
            return Ok(motorcycles);
        }

        /// <summary>
        /// Retorna motocicleta pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Motorcycle>> GetById(int id)
        {
            var motorcycle = await _service.GetByIdAsync(id);
            if (motorcycle == null) return NotFound();
            return Ok(motorcycle);
        }

        /// <summary>
        /// Cria uma nova motocicleta.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Motorcycle>> Create(Motorcycle motorcycle)
        {
            var created = await _service.CreateAsync(motorcycle);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza uma motocicleta existente.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Motorcycle motorcycle)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.UpdateAsync(id, motorcycle);
            return NoContent();
        }

        /// <summary>
        /// Deleta uma motocicleta pelo ID.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
