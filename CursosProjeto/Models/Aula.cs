using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoProjeto.Models
{
    public class Aula
    {
        public int Id { get; set; }
        
        public int ModuloId { get; set; }

        [ForeignKey("ModuloId")]
        public virtual Modulo? modulo { get; set; }

        [Required]
        public string DescricaoAula { get; set; }
        [Required]
        public string UlrAula { get; set; }
    }
}