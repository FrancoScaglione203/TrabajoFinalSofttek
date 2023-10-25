using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoFinalSofttek.Entities;
using System;
using TrabajoFinalSofttek.DTOs;

namespace TrabajoFinalSofttek.Entities
{
    public class Historial
    {

        public Historial(HistorialDto dto)
        {
            UsuarioId = dto.UsuarioId;
            CuilDestino = dto.CuilDestino;
            TipoMovimientoId = dto.TipoMovimientoId;
            MonedaId = dto.MonedaId;
            Monto = dto.Monto;
        }

        public Historial(int usuarioId, long cuil, int tipoMovimientoId, int monedaId, decimal monto)
        {
            UsuarioId = usuarioId;
            CuilDestino = cuil;
            TipoMovimientoId = tipoMovimientoId;
            MonedaId = monedaId;
            Monto = monto;
        }

        public Historial()
        {

        }

        [Key]
        [Column("historial_id")]
        public int Id { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        [Column("historial_cuil_destino")]
        public long CuilDestino { get; set; }

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