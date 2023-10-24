using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoFinalSofttek.Entities;
using System.Net;

namespace TrabajoFinalSofttek.DTOs
{
    public class UsuarioDto
    {

        public long Cuil { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
    }
}
