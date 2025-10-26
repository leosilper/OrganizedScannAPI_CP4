using Microsoft.AspNetCore.Mvc;
using OrganizedScannApi.Domain.Repositories;

namespace OrganizedScannApi.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PortalController : ControllerBase
    {
        private readonly IPortalRepository _repository;

        public PortalController(IPortalRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todos os portais.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var portals = await _repository.GetAllAsync();
            return Ok(portals);
        }

        /// <summary>
        /// Retorna portal pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var portal = await _repository.GetByIdAsync(id);
            if (portal == null) return NotFound();
            return Ok(portal);
        }

        /// <summary>
        /// Cria um novo portal.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrganizedScannApi.Domain.Entities.Portal portal)
        {
            await _repository.AddAsync(portal);
            return CreatedAtAction(nameof(GetById), new { id = portal.Id }, portal);
        }
    }
}