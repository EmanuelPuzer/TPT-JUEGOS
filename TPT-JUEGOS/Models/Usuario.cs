using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


namespace TPT_JUEGOS.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Display(Name = "Nombre completo")]
        public string NOMBRE_PERSONA { get; set; }
        [Display(Name = "Edad")]
        public int EDAD_USUARIO { get; set; }
        [Display(Name = "Nombre de usuario")]
        public string NOMBRE_USUARIO { get; set; }
        [Display(Name = "Correo electronico")]
        public string CORREO_USUARIO { get; set; }
        [Display(Name = "Contraseña")]
        public string CONTRASENA_USUARIO { get; set; }

        // 0= Usuario normal 1= Administrador
        public int TIPO_USUARIO { get; set; }

    }
}
