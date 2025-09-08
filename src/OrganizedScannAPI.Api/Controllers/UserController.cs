using Microsoft.AspNetCore.Http;
﻿// Controllers/UserController.cs
using Microsoft.AspNetCore.Mvc;
using OrganizedScannApi.Infrastructure.Data;
using System.Threading.Tasks;

namespace OrganizedScannApi.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/users")]
        public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context) => _context = context;

        /// <summary>
        /// Deleta usuário pelo ID (apenas ADMIN).
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}