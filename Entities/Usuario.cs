using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalSofttek.Entities
{
    public class Usuario
    {
        [Key]
        [Column("usuario_id")]
        public int Id { get; set; }

        [Required]
        [Column("usuario_cuil")]
        public long Cuil { get; set; }

        [Required]
        [Column("usuario_clave", TypeName = "VARCHAR(250)")]
        public string Clave { get; set; }

        [Required]
        [Column("cuentaFiduciaria_id")]
        public int CuentaFiduciariaId { get; set; }
        public CuentaFiduciaria CuentaFiduciaria { get; set; }

        [Required]
        [Column("cuentaCripto_id")]
        public int CuentaCriptoId { get; set; }
        public CuentaCripto CuentaCripto { get; set; }

        [Required]
        [Column("usuario_activo")]
        public bool Activo { get; set; }
    }
}
