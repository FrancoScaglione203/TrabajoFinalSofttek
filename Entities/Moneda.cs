using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalSofttek.Entities
{
    public class Moneda
    {
        [Column("moneda_id")]
        public int Id { get; set; }

        [Column("moneda_descripcion")]
        public string Descripcion { get; set; }
    }
}
