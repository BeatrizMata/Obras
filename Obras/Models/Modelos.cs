using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Obras.Models
{
    public class Modelos
    {
    }
    public enum StatusObra {
        PorIniciar,
        Iniciado,
        Terminado
    }
[Table("Obra")]
    public class Obra{
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string CveObra { get; set; }
        [MaxLength(250)]
        public string Descripcion { get; set; }
        [MaxLength(250)]
        public string Ubicacion { get; set; }
        [MaxLength(250)]
        public string Convenio{ get; set; }
        public  StatusObra Estatus { get; set; }
    }

    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name ="Correo Electrónico")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength =6)]
        public string Password { get; set; }
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }
        [StringLength(150)]
        public string Apellidos { get; set; }

        public bool Activo { get; set; }
    }
    //View Model para logueo
    public class ViewLogin
    {
        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}