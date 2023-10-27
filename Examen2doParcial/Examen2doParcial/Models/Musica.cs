using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen2doParcial.Models
{
    public class Musica
    {
        [Key]
        public int Id_Musica { get; set; }
        public string titulo { get; set; }

        public string Genero { get; set; }
        public int NumeroReproducciones { get; set; }

        [ForeignKey("Disco")]
        public int Id_Disco { get; set; }
        public Disco Disco { get; set; }
    }
}
