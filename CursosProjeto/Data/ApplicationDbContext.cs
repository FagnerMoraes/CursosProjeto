using CursoProjeto.Models;
using CursosProjeto.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CursosProjeto.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CursoConfiguration());
        }


        public DbSet<Curso> cursos { get; set; }
        public DbSet<Modulo> modulos { get; set; }
        public DbSet<Aula> aulas { get; set; }
    }
}