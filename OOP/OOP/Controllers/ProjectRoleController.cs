using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    [Route("api/[controller]")]
    [ApiController]
    public class ProjectRolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectRole>>> GetProjectRoles()
        {
            try
            {
                var roles = await _context.projectRoles.ToListAsync();
                return Ok(roles); // 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/ProjectRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectRole>> GetProjectRole(int id)
        {
            try
            {
                var role = await _context.projectRoles.FindAsync(id);

                if (role == null)
                {
                    return NotFound();
                }

                return Ok(role); // 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/ProjectRoles
        [HttpPost]
        public async Task<ActionResult<ProjectRole>> PostProjectRole(ProjectRole role)
        {
            try
            {
                _context.projectRoles.Add(role);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProjectRole), new { id = role.role_id }, role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/ProjectRoles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectRole(int id, ProjectRole role)
        {
            try
            {
                if (id != role.role_id)
                {
                    return BadRequest();
                }

                _context.Entry(role).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectRoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // DELETE: api/ProjectRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectRole(int id)
        {
            try
            {
                var role = await _context.projectRoles.FindAsync(id);
                if (role == null)
                {
                    return NotFound();
                }

                _context.projectRoles.Remove(role);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        private bool ProjectRoleExists(int id)
        {
            return _context.projectRoles.Any(e => e.role_id == id);
        }
    }

