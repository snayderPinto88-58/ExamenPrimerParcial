using Examen2doParcial.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen2doParcial.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Disco> discos { get; set; }
        public DbSet<Musica> musicas { get; set; }
    }
}
