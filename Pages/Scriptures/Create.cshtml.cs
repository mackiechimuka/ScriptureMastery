using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureMastery.Data;
using ScriptureMastery.Models;

namespace ScriptureMastery.Pages.Scriptures
{
    public class CreateModel : PageModel
    {
        private readonly ScriptureMastery.Data.ScriptureMasteryContext _context;

        public CreateModel(ScriptureMastery.Data.ScriptureMasteryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            IQueryable<Book> bookQuery = from m in _context.Book
                                         select m;

            var BookQuery = await bookQuery.Distinct().ToListAsync();

            ViewData["BookId"] = new SelectList(BookQuery, "BookId", "BookName");
            return Page();
        }

        [BindProperty]
        public Scripture Scripture { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Scripture == null || Scripture == null)
            {
                return Page();
            }

            _context.Scripture.Add(Scripture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
