using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.Entities
{
    public class Historial
    {
        [Key]
        [Column("historial_id")]
        public int Id { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Column("tipoMovimiento_id")]
        public int TipoMovimientoId { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }

        [Column("moneda_id")]
        public int MonedaId { get; set; }
        public Moneda Moneda { get; set; }

        [Required]
        [Column("historial_monto")]
        public decimal Monto { get; set; }


    }
}