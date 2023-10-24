using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TrabajoFinalSofttek.DTOs;

namespace TrabajoFinalSofttek.Entities
{
    public class Usuario
    {
        public Usuario(UsuarioDto dto)
        {
            Cuil = dto.Cuil;
            Clave = dto.Clave;
            Activo = true;
        }

        public Usuario()
        {

        }

        [Key]
        [Column("usuario_id")]
        public int Id { get; set; }

        [Required]
        [Column("usuario_cuil")]
        public long Cuil { get; set; }

        [Required]
        [Column("usuario_nombre")]
        public string Nombre { get; set; }

        [Required]
        [Column("usuario_apellido")]
        public string Apellido { get; set; }

        [Required]
        [Column("usuario_clave", TypeName = "VARCHAR(250)")]
        public string Clave { get; set; }

        [Required]
        [Column("usuario_activo")]
        public bool Activo { get; set; }
    }
}
