using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoFinalSofttek.DTOs;

namespace TrabajoFinalSofttek.Entities
{
    public class CuentaCripto
    {
        public CuentaCripto(CuentaCriptoDto dto)
        {
            UsuarioId = dto.UsuarioId;
            UUID = dto.UUID;
            Saldo = dto.Saldo;
            Activo = true;
        }

        public CuentaCripto()
        {

        }

        [Column("cuentaCripto_id")]
        public int Id { get; set; }


        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Column("cuentaCripto_UUID")]
        public long UUID { get; set; }

        [Column("cuentaCripto_saldo")]
        public decimal Saldo { get; set; }

        [Column("cuentaCripto_activo")]
        public bool Activo { get; set; }

    }
}
