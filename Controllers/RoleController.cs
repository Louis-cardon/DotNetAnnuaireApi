namespace DotNetAnnuaireApi.Controllers
{
    using System.Collections.Generic;
    using DotNetAnnuaireApi.Models;
    using DotNetAnnuaireApi.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> PostRole([FromBody] Role role)
        {
            if (role == null)
            {
                return BadRequest();
            }

            await _roleService.AddRoleAsync(role);
            return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, [FromBody] Role role)
        {
            if (role == null || id != role.Id)
            {
                return BadRequest();
            }

            var existingRole = await _roleService.GetRoleByIdAsync(id);

            if (existingRole == null)
            {
                return NotFound();
            }

            await _roleService.UpdateRoleAsync(role);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            await _roleService.DeleteRoleAsync(id);

            return NoContent();
        }
    }
}
