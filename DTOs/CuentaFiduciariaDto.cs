using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalSofttek.DTOs
{
    public class CuentaFiduciariaDto
    {
        public int UsuarioId { get; set; }
        public long CBU { get; set; }
        public string Alias { get; set; }
        public int NumeroCuenta { get; set; }
        public decimal SaldoPesos { get; set; }
        public decimal SaldoDolares { get; set; }
        public bool Activo { get; set; }
    }
}
