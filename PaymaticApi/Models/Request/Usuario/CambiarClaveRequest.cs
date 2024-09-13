namespace ActivPayApi.Models.Request.Usuario
{
    public class CambiarClaveRequest
    {
        public string Token { get; set; }

        public string Clave { get; set; }

        public string NuevaClave { get; set; }

        public string ConfirmarClave { get; set; }
    }
}
