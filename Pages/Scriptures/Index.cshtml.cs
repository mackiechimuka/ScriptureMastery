using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScriptureMastery.Data;
using ScriptureMastery.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ScriptureMastery.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureMastery.Data.ScriptureMasteryContext _context;

        public IndexModel(ScriptureMastery.Data.ScriptureMasteryContext context)
        {
            _context = context;
        }

        public IList<ScriptureIndexStruct> Scripture { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? BookString { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime? OrderBy { get; set; }
        public SelectList ListItems { get; set; }


        public async Task OnGetAsync()
        {
            IQueryable<DateTime> dateQuery = from w in _context.Scripture
                                             orderby w.CreatedDate
                                             select w.CreatedDate;

            var scriptures = from m in _context.Scripture
                             join p in _context.Book on m.BookId equals p.BookId
                             select new ScriptureIndexStruct
                             {
                                 ScriptureId = m.ScriptureId
                             ,
                                 BookId = m.BookId
                             ,
                                 Chapter = m.Chapter
                             ,
                                 Verses = m.Verses
                             ,
                                 Notes = m.Notes
                             ,
                                 CreatedDate = m.CreatedDate
                             ,
                                 Books = p.BookName
                             };




            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(BookString))
            {
                scriptures = scriptures.Where(b => b.Books.Contains(BookString));
            }

            if (OrderBy != null)
            {
                scriptures = scriptures.Where(g => g.CreatedDate == OrderBy);
            }
            ListItems = new SelectList(await dateQuery.Distinct().ToListAsync());

            Scripture = await scriptures.ToListAsync();

        }
    }
}

