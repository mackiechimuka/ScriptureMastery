using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureMastery.Data;
using ScriptureMastery.Models;

namespace ScriptureMastery.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureMastery.Data.ScriptureMasteryContext _context;

        public IndexModel(ScriptureMastery.Data.ScriptureMasteryContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book.ToListAsync();
            }
        }
    }
}
