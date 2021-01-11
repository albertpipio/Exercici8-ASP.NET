using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorEmpleats.Data;
using RazorEmpleats.Models;

namespace RazorEmpleats.Pages.Empleats
{
    public class EditModel : PageModel
    {
        private readonly RazorEmpleats.Data.EmpleatContext _context;

        public EditModel(RazorEmpleats.Data.EmpleatContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmpleatInfo EmpleatInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpleatInfo = await _context.EmpleatInfo.FirstOrDefaultAsync(m => m.ID == id);

            if (EmpleatInfo == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmpleatInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleatInfoExists(EmpleatInfo.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmpleatInfoExists(int id)
        {
            return _context.EmpleatInfo.Any(e => e.ID == id);
        }
    }
}
