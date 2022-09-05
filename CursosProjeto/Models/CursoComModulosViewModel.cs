using CursoProjeto.Models;

namespace CursosProjeto.Models
{
    public class CursoComModulosViewModel
    {
        //Inicio dados Curso
        public string? Tag { get; set; }

        public string? Titulo { get; set; }

        public string? Sumario { get; set; }

        public string? duracaoEmMinutos { get; set; }

        //Fim dados Curso

        //inicio dados Modulos
        public ICollection<Modulo>? modulos { get; set; }
        //Fim dados Modulos

        //Inicio dados Aulas
        public ICollection<Aula>? aulas { get; set; }
        //Fim Dados Aulas
    }
}
