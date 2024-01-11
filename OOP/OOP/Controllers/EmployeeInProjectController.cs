using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeInProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeInProjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeInProject>>> GetEmployeeInProjects()
        {
            try
            {
                var assignments = await _context.employeesInProject.ToListAsync();
                return Ok(assignments); // 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/EmployeeInProjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeInProject>> GetEmployeeInProject(int id)
        {
            try
            {
                var assignment = await _context.employeesInProject.FindAsync(id);

                if (assignment == null)
                {
                    return NotFound();
                }

                return Ok(assignment); // 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/EmployeeInProjects
        [HttpPost]
        public async Task<ActionResult<EmployeeInProject>> PostEmployeeInProject(EmployeeInProject employeeInProject)
        {
            try
            {
                _context.employeesInProject.Add(employeeInProject);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEmployeeInProject), new { id = employeeInProject.assignment_id }, employeeInProject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/EmployeeInProjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeInProject(int id, EmployeeInProject employeeInProject)
        {
            try
            {
                if (id != employeeInProject.assignment_id)
                {
                    return BadRequest();
                }

                _context.Entry(employeeInProject).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeInProjectExists(id))
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

        // DELETE: api/EmployeeInProjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeInProject(int id)
        {
            try
            {
                var assignment = await _context.employeesInProject.FindAsync(id);
                if (assignment == null)
                {
                    return NotFound();
                }

                _context.employeesInProject.Remove(assignment);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        private bool EmployeeInProjectExists(int id)
        {
            return _context.employeesInProject.Any(e => e.assignment_id == id);
        }
    
}
