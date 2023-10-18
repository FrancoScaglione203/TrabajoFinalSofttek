using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalSofttek.Entities
{
    public class TipoMovimiento
    {
        [Column("tipoMovimiento_id")]
        public int Id { get; set; }

        [Column("tipoMovimiento_descripcion")]
        public string Descripcion { get; set; }
    }
}
