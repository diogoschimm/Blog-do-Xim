using System;

namespace BlogDoXim.ApiDados.ViewModels
{
    public class TokenAuthentication
    {
        public DateTime Expires { get; set; }
        public string StrToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
