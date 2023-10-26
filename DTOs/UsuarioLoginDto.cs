using System.Runtime.ConstrainedExecution;

namespace TrabajoFinalSofttek.DTOs
{
    public class UsuarioLoginDto
    {
        //public int Id {  get; set; }    VER SI NECESITO PASAR EL ID, SE RECOMIENDO NO PASARLO POR BODY
        public long Cuil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Token { get; set; }
    }
}
