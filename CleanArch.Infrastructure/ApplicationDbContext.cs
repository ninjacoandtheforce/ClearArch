using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
    }
}
