using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScriptureMastery.Models;

namespace ScriptureMastery.Data
{
    public class ScriptureMasteryContext : DbContext
    {
        public ScriptureMasteryContext (DbContextOptions<ScriptureMasteryContext> options)
            : base(options)
        {
        }

        public DbSet<ScriptureMastery.Models.Book> Book { get; set; } = default!;

        public DbSet<ScriptureMastery.Models.Scripture> Scripture { get; set; } = default!;
    }
}
