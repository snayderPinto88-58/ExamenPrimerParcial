using System.ComponentModel.DataAnnotations;

namespace Examen2doParcial.Models
{
    public class Disco
    {
        [Key]
        public int Id_Disco { get; set; }
        public string titulo { get; set; }

        public string autor { get; set; }
        public string year { get; set; }
    }
}
