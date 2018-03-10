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

    
    public enum StatusEmpresa
    {
        Activo,
        Refrendado,
        Inactivo
    }
    public enum TipoContacto
    {
        Telefono,
        Correo
    }

    
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }
        //public Usuarios IdUsuario { get; set; }
        [MaxLength(12)]
        public string RFC { get; set; }
        [MaxLength(250)]
        public string RepresLegal { get; set; }
        [MaxLength(250)]
        public string Tecnico { get; set; }
        [MaxLength(250)]
        public string RegistroEdo { get; set; }
        [MaxLength(250)]
        public string NumIMSS { get; set; }
        public double CapitalSocial { get; set; }
        public double CapitalContable { get; set; }
        [MaxLength(100)]
        public string CMIC { get; set; }
        [MaxLength(100)]
        public string CNEC { get; set; }
        public DateTime FechaRegistro { get; set; }
        public StatusEmpresa Estatus { get; set; }

    }
    [Table("Domicilio")]
    public class Domicilio
    {
        [Key]
        public int IdDom { get; set; }
        //public Usuarios IdUsuario { get; set; }
        [MaxLength(200)]
        public string Colonia { get; set; }
        [MaxLength(6)]
        public string CodigoP { get; set; }
        [MaxLength(250)]
        public string Calle { get; set; }
        [MaxLength(250)]
        public string Ciudad { get; set; }
        [MaxLength(250)]
        public string Estado { get; set; }

    }
    [Table("Contacto")]
    public class Contacto
    {
        [Key]
        public int IdContacto { get; set; }
        //public Usuarios IdUsuario { get; set; }
        public TipoContacto TContacto { get; set; }
        [MaxLength(250)]
        public string Descripcion { get; set; }

    }
    [Table("Especialidad")]
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }
        public Empresa IdEmpresa { get; set; }
        [MaxLength(250)]
        public string DescEspecialidad { get; set; }

    }

}