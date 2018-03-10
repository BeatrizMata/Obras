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
    public class obra{
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
}