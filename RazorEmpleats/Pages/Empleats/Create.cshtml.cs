using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorEmpleats.Data;
using RazorEmpleats.Models;

namespace RazorEmpleats.Pages.Empleats
{
    public class CreateModel : PageModel
    {
        private readonly RazorEmpleats.Data.EmpleatContext _context;

        public CreateModel(RazorEmpleats.Data.EmpleatContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EmpleatInfo EmpleatInfo { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EmpleatInfo.Add(EmpleatInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
