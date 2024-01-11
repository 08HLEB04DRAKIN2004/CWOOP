using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class MediaResourcesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MediaResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MediaResources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaResource>>> GetMediaResources()
        {
            try
            {
                var resources = await _context.mediaResources.ToListAsync();
                return Ok(resources); // 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/MediaResources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaResource>> GetMediaResource(int id)
        {
            try
            {
                var resource = await _context.mediaResources.FindAsync(id);

                if (resource == null)
                {
                    return NotFound();
                }

                return Ok(resource); // 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/MediaResources
        [HttpPost]
        public async Task<ActionResult<MediaResource>> PostMediaResource(MediaResource mediaResource)
        {
            try
            {
                _context.mediaResources.Add(mediaResource);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMediaResource), new { id = mediaResource.resource_id }, mediaResource);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/MediaResources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediaResource(int id, MediaResource mediaResource)
        {
            try
            {
                if (id != mediaResource.resource_id)
                {
                    return BadRequest();
                }

                _context.Entry(mediaResource).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaResourceExists(id))
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

        // DELETE: api/MediaResources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediaResource(int id)
        {
            try
            {
                var resource = await _context.mediaResources.FindAsync(id);
                if (resource == null)
                {
                    return NotFound();
                }

                _context.mediaResources.Remove(resource);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        private bool MediaResourceExists(int id)
        {
            return _context.mediaResources.Any(e => e.resource_id == id);
        }
    }
