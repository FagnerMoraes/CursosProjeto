using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoProjeto.Models
{
    public class Modulo
    {
        
        public int Id { get; set; }

        public int CursoId { get; set; }

        [ForeignKey("CursoId")]
        public virtual Curso? curso { get; set; }

        [Display(Name ="Descricao"), MaxLength(200)]
        public string? DescricaoDoModulo { get; set; }

        [Required, Display(Name = "Ordem que sera exibido"), Range(1,100, ErrorMessage ="A ordem vai de 1 a 100")]
        public int OrdemDeExibicao { get; set; }



        public virtual ICollection<Aula>? aulas { get; set; }


    }
}