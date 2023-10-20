using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalSofttek.DTOs
{
    public class CuentaCriptoDto
    {
        public long UUID { get; set; }
        public decimal Saldo { get; set; }
        public bool Activo { get; set; }
    }
}
