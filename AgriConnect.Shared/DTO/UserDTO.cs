using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriConnect.Shared.DTO
{
    public class UserDTO:User
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} tiene una longitud maxima de {1} caracter.")]
        [Display(Name ="Contraseña")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} tiene una longitud maxima de {1} caracter.")]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage ="Contraseñas no coinciden")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }
    }
}
