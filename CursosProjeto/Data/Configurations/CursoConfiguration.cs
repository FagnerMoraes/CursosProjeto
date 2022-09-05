using CursoProjeto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursosProjeto.Data.Configurations
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasData(
                new Curso
                {
                    Id = 1,
                    Titulo = "Curso01",
                    Tag = "1111",
                    Sumario = "Informacao que não sei do Curso01",
                    duracaoEmMinutos = 100,

                },
                new Curso
                {
                    Id = 2,
                    Titulo = "Curso02",
                    Tag = "2222",
                    Sumario = "Informacao que não sei do Curso02",
                    duracaoEmMinutos = 200,

                },
                new Curso
                {
                    Id = 3,
                    Titulo = "Curso03",
                    Tag = "3333",
                    Sumario = "Informacao que não sei do Curso03",
                    duracaoEmMinutos = 300
                }
                );
        }
    }
}
