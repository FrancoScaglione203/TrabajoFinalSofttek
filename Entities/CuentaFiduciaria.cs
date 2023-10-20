using System;
using System.ComponentModel.DataAnnotations.Schema;
using TrabajoFinalSofttek.DTOs;

namespace TrabajoFinalSofttek.Entities
{
    public class CuentaFiduciaria
    {
        public CuentaFiduciaria(CuentaFiduciariaDto dto)
        {
            CBU = dto.CBU;
            Alias = dto.Alias;
            NumeroCuenta = dto.NumeroCuenta;
            SaldoPesos = dto.SaldoPesos;
            SaldoDolares = dto.SaldoDolares;
            Activo = true;
        }

        public CuentaFiduciaria()
        {

        }

        [Column("cuentaFiduciaria_id")]
        public int Id { get; set; }

        [Column("cuentaFiduciaria_CBU")]
        public long CBU { get; set; }

        [Column("cuentaFiduciaria_alias")]
        public string Alias { get; set; }

        [Column("cuentaFiduciaria_numeroCuenta")]
        public int NumeroCuenta { get; set; }

        [Column("cuentaFiduciaria_saldoPesos")]
        public decimal SaldoPesos { get; set; }

        [Column("cuentaFiduciaria_saldoDolares")]
        public decimal SaldoDolares { get; set; }

        [Column("cuentaFiduciaria_activo")]
        public bool Activo { get; set; }
    }
}
