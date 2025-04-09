using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriConnect.Shared
{
    public class User:IdentityUser
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} tiene una longitud maxima de {1} caracter.")]
        [Display(Name = "Nombres(s)")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} tiene una longitud maxima de {1} caracter.")]
        [Display(Name = "Apellido (s)")]
        public string LastName { get; set; } = null!;

        [Display(Name ="Foto")]
        [DataType(DataType.ImageUrl)]
        public string? PhotoUrl { get; set; }
        public UserType UserType { get; set; }

        [Display(Name = "Ciudad")]
        [Range(1,int.MaxValue,ErrorMessage ="Debes seleccionar {0}.")]
        public int CityId { get; set; }
        public City? City { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

    }
}
