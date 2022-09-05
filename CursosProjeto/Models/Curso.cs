using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoProjeto.Models
{
    public class Curso
    {
        public int Id { get; set; }
       
        [Required, StringLength(50)]
        public string? Titulo { get; set; }

        [Required, StringLength(4), MinLength(4), Range(0000,9999,ErrorMessage ="A tag deve conter 4 digitos")]
        public string?  Tag { get; set; }

        [Required, StringLength(500)]
        public string? Sumario { get; set; }
       
        [Required,Display(Name ="Duracao")]
        public int duracaoEmMinutos { get; set; }

        public virtual ICollection<Modulo>? modulos { get; set; }


    }
}
