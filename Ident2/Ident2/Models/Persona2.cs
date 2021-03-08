using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ident2.Models
{
    public enum SexType
    {
        Femenino=0,
        Masculino=1,
    }
    public class Persona2
    {
        [Key]
        public int Persona2Id { get; set; }

        [Required]
        [StringLength(250,MinimumLength =5,ErrorMessage ="Ingrese nombre entre 5 a 250 caracteres")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Ingrese correo valido")]
        public string correo { get; set; }
        public SexType Sex { get; set; }
    }

}