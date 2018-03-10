using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Display(Name ="Clave de Obra")]
        public string CveObra { get; set; }
        [MaxLength(250)]
        [Display(Name ="Descripción")]
        public string Descripcion { get; set; }
        [MaxLength(250)]
        [Display(Name ="Ubicación")]
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
        public int Id { get; set; }
        [Required]
        public Usuarios IdUsuario { get; set; }
        [MaxLength(12)]
        public string RFC { get; set; }
        [MaxLength(250)]
        [Display(Name ="Representante Legal")]
        public string RepresLegal { get; set; }
        [MaxLength(250)]
        [Display(Name="Representante Técnico")]
        public string Tecnico { get; set; }
        [MaxLength(250)]
        [Display(Name ="Folio de Registro")]
        public string RegistroEdo { get; set; }
        [MaxLength(250)]
        [Display(Name ="Número de Seguro")]
        public string NumIMSS { get; set; }
        [Display(Name ="Capital Social")]
        [DefaultValue(0)]
        public double CapitalSocial { get; set; }
        [Display(Name ="Capital Contable")]
        [DefaultValue(0)]
        public double CapitalContable { get; set; }
        [Display(Name ="Camara Méxicana de la Industria de la Construcción")]
        [MaxLength(100)]
        public string CMIC { get; set; }
        [MaxLength(100)]
        [Display(Name ="Camara Nacional de Empresas de consultoria")]
        public string CNEC { get; set; }
        [Display(Name ="Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }
        [Display(Name ="Estatus")]
        [Required]
        public StatusEmpresa Estatus { get; set; }

    }
    [Table("Domicilio")]
    public class Domicilio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Usuarios IdUsuario { get; set; }
        [MaxLength(200)]
        public string Colonia { get; set; }
        [MaxLength(6)]
        [Display(Name ="Código Postal")]
        public string CodigoP { get; set; }
        [MaxLength(250)]
        [Display(Name ="Calle")]
        public string Calle { get; set; }
        [MaxLength(250)]
        [Display(Name="Ciudad")]
        public string Ciudad { get; set; }
        [MaxLength(250)]
        public string Estado { get; set; }

    }
    [Table("Contacto")]
    public class Contacto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Empresa IdEmpresa { get; set; }
        [MaxLength(250)]
        [Display(Name ="Descripción")]
        public string Descripcion { get; set; }

    }
    [Table("Especialidad")]
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        [Display(Name ="Descripción")]
        public string Descripcion { get; set; }

    }
    [Table("EspecialidadEmpresa")]
    public class EspecialidadEmpresa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Empresa IdEmpresa { get; set; }
        [Required]
        public Especialidad IdEspecialidad { get; set; }
    }

}