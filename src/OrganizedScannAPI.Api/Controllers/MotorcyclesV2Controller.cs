using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizedScannApi.Domain.Entities;
using OrganizedScannApi.Application.UseCases.Motorcycles;

namespace OrganizedScannApi.Api.Controllers
{
    /// <summary>
    /// Controller V2 - Motorcycles com funcionalidades estendidas
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class MotorcyclesV2Controller : ControllerBase
    {
        private readonly MotorcycleService _service;

        public MotorcyclesV2Controller(MotorcycleService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todas as motocicletas, podendo filtrar por marca e ano (V2).
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Motorcycle>>> GetAll([FromQuery] string? brand, [FromQuery] int? year)
        {
            var motorcycles = await _service.GetAllAsync(brand, year);
            return Ok(motorcycles);
        }

        /// <summary>
        /// Retorna motocicleta pelo ID (V2).
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Motorcycle>> GetById(int id)
        {
            var motorcycle = await _service.GetByIdAsync(id);
            if (motorcycle == null) return NotFound();
            return Ok(motorcycle);
        }

        /// <summary>
        /// Cria uma nova motocicleta (V2).
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Motorcycle>> Create(Motorcycle motorcycle)
        {
            var created = await _service.CreateAsync(motorcycle);
            return CreatedAtAction(nameof(GetById), new { id = created.Id, version = "2.0" }, created);
        }
    }
}

