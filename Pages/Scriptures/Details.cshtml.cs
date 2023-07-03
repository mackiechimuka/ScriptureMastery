using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureMastery.Data;
using ScriptureMastery.Models;

namespace ScriptureMastery.Pages.Scriptures
{
    public class DetailsModel : PageModel
    {
        private readonly ScriptureMastery.Data.ScriptureMasteryContext _context;

        public DetailsModel(ScriptureMastery.Data.ScriptureMasteryContext context)
        {
            _context = context;
        }

        public Scripture Scripture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Scripture == null)
            {
                return NotFound();
            }

            var scripture = await _context.Scripture.FirstOrDefaultAsync(m => m.ScriptureId == id);
            if (scripture == null)
            {
                return NotFound();
            }
            else
            {
                Scripture = scripture;
            }
            return Page();
        }
    }
}
