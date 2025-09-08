using Microsoft.AspNetCore.Http;
﻿// Controllers/PortalController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizedScannApi.Infrastructure.Data;
using OrganizedScannApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizedScannApi.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/portals")]
        public class PortalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PortalController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna resumo das motocicletas por portal.
        /// </summary>
        [HttpGet("summary")]
        public async Task<ActionResult<List<PortalSummaryDTO>>> ListSummary()
        {
            var portals = await _context.Portals.ToListAsync();
            var motorcycles = await _context.Motorcycles.Include(m => m.Portal).ToListAsync();

            var result = portals.Select(portal => new PortalSummaryDTO
            {
                PortalName = portal.Name,
                MotorcycleCount = motorcycles.Count(m => m.PortalId == portal.Id),
                MotorcyclePlates = motorcycles
                    .Where(m => m.PortalId == portal.Id)
                    .Select(m => m.LicensePlate)
                    .ToList()
            }).ToList();

            return Ok(result);
        }
    }
}