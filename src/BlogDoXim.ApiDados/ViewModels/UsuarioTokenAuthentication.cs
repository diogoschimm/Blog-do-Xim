namespace BlogDoXim.ApiDados.ViewModels
{
    public class UsuarioTokenAuthentication
    {
        public int UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public TokenAuthentication Token { get; set; }
    }
}
