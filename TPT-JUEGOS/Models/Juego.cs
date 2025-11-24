using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


namespace TPT_JUEGOS.Models
{
    public class Juego
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_JUEGO { get; set; }
        [Display(Name = "Nombre Juego")]
        public string NOMBRE_JUEGO { get; set; }

        [Display(Name = "Juego Activo")]
        public int  JUEGO_ACTIVO { get; set; }
 
        [Display(Name = "Codigo Juego")]
        public string CODIGO_JUEGO { get; set; }

        public string NOMBRE_IMAGEN { get; set; }

    }
}

