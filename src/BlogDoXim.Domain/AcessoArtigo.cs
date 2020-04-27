using BlogDoXim.Domain.Base;
using System;

namespace BlogDoXim.Domain
{
    public class AcessoArtigo : Entity 
    {
        public int AcessoArtigoId { get; set; }
        public string IP { get; set; }
        public DateTime DataAcesso { get; set; }

        public int ArtigoId { get; set; }
        public Artigo Artigo { get; set; }
    }
}
