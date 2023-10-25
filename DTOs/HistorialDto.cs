using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DTOs
{
    public class HistorialDto
    {
        public int UsuarioId { get; set; }
        public long CuilDestino { get; set; }
        public int TipoMovimientoId { get; set; }
        public int MonedaId { get; set; }
        public decimal Monto { get; set; }
    }
}
