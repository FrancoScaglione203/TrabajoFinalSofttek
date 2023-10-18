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
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Column("tipoMovimiento_id")]
        public int IdTipoMovimiento { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }

        [Column("moneda_id")]
        public int IdMoneda { get; set; }
        public Moneda Moneda { get; set; }
    }
}