using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiEmpleatsDTO.Data;
using ApiEmpleatsDTO.Models;

namespace ApiEmpleatsDTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleatInfoController : ControllerBase
    {
        private readonly EmpleatContext _context;

        public EmpleatInfoController(EmpleatContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleatInfoDTO>>> GetEmpleatsInfo()
        {
            return await _context.EmpleatsInfo
                .Select(x => EmpleatToDTO(x))
                .ToListAsync();
        }

        // GET: api/EmpleatInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleatInfoDTO>> GetEmpleatInfo(long id)
        {
            var empleatInfo = await _context.EmpleatsInfo.FindAsync(id);

            if (empleatInfo == null)
            {
                return NotFound();
            }

            return EmpleatToDTO(empleatInfo);
        }

        // PUT: api/EmpleatInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleatInfo(long id, EmpleatInfoDTO empleatInfoDTO)
        {
            if (id != empleatInfoDTO.Id)
            {
                return BadRequest();
            }

            var empleatInfo = await _context.EmpleatsInfo.FindAsync(id);
            if (empleatInfo == null)
            {
                return NotFound();
            }

            empleatInfo.Name = empleatInfoDTO.Name;
            empleatInfo.Surname = empleatInfoDTO.Surname;
            empleatInfo.Position = empleatInfoDTO.Position;
            empleatInfo.Salary = empleatInfoDTO.Salary;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!EmpleatInfoExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/EmpleatInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpleatInfoDTO>> CreateTodoItem(EmpleatInfoDTO empleatInfoDTO)
        {
            var empleatInfo = new EmpleatInfo
            {
                Name = empleatInfoDTO.Name,
                Surname = empleatInfoDTO.Surname,
                Position = empleatInfoDTO.Position,
                Salary = empleatInfoDTO.Salary
            };

            _context.EmpleatsInfo.Add(empleatInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetEmpleatInfo),
                new { id = empleatInfo.Id },
                EmpleatToDTO(empleatInfo));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var empleatInfo = await _context.EmpleatsInfo.FindAsync(id);

            if (empleatInfo == null)
            {
                return NotFound();
            }

            _context.EmpleatsInfo.Remove(empleatInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleatInfoExists(long id)
        {
            return _context.EmpleatsInfo.Any(e => e.Id == id);
        }

        private static EmpleatInfoDTO EmpleatToDTO(EmpleatInfo empleatInfo) =>
    new EmpleatInfoDTO
    {
        Id = empleatInfo.Id,
        Name = empleatInfo.Name,
        Surname = empleatInfo.Surname,
        Position = empleatInfo.Position,
        Salary = empleatInfo.Salary
    };
    }
}
