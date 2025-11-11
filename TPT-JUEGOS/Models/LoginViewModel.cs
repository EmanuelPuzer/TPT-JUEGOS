using System.ComponentModel.DataAnnotations;

namespace TPT_JUEGOS.Models
{
    public class LoginViewModel
    {
        
        [Required(ErrorMessage = "El usuario o correo es obligatorio")]
        [Display(Name = "Usuario o Correo Electrónico")]
        public string UsuarioOEmail { get; set; } 

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
    }
}