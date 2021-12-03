using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.New.API.Data
{
    public class MoviesDbContext: DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
        : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
