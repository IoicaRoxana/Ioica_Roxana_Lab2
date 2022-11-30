using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ioica_Roxana_Lab2.Models;

namespace Ioica_Roxana_Lab2.Data
{
    public class Ioica_Roxana_Lab2Context : DbContext
    {
        public Ioica_Roxana_Lab2Context (DbContextOptions<Ioica_Roxana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Ioica_Roxana_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Ioica_Roxana_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Ioica_Roxana_Lab2.Models.Author> Author { get; set; }

        public DbSet<Ioica_Roxana_Lab2.Models.Category> Category { get; set; }

        public DbSet<Ioica_Roxana_Lab2.Models.Category> BookCategory { get; set; }

        public DbSet<Ioica_Roxana_Lab2.Models.Member> Member { get; set; }

        public DbSet<Ioica_Roxana_Lab2.Models.Borrowing> Borrowing { get; set; }
    }
}
