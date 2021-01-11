using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorEmpleats.Models;

namespace RazorEmpleats.Pages.Empleats
{
    public class IndexModel : PageModel
    {
        private readonly RazorEmpleats.Data.EmpleatContext _context;

        public IndexModel(RazorEmpleats.Data.EmpleatContext context)
        {
            _context = context;
        }

        public IList<EmpleatInfo> EmpleatInfo { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> PositionQuery = from m in _context.EmpleatInfo
                                            orderby m.Position
                                            select m.Position;

            var empleatInfo = from e in _context.EmpleatInfo
                         select e;
            if (!string.IsNullOrEmpty(SearchString))
            {
                empleatInfo = empleatInfo.Where(s => s.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                empleatInfo = empleatInfo.Where(x => x.Position == MovieGenre);
            }
            Genres = new SelectList(await PositionQuery.Distinct().ToListAsync());
            
            EmpleatInfo = await empleatInfo.ToListAsync();
        }
    }
}
