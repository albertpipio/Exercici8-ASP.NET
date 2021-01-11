using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorEmpleats.Data;
using RazorEmpleats.Models;

namespace RazorEmpleats.Pages.Empleats
{
    public class DetailsModel : PageModel
    {
        private readonly RazorEmpleats.Data.EmpleatContext _context;

        public DetailsModel(RazorEmpleats.Data.EmpleatContext context)
        {
            _context = context;
        }

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
    }
}
