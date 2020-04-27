using BlogDoXim.Domain.Base;
using System;
using System.Collections.Generic;

namespace BlogDoXim.Domain
{
    public class Artigo : Entity
    {
        public int ArtigoId { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Resumo { get; set; }
        public string Conteudo { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public byte[] Imagem { get; set; }
        public string GithubUrl { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<AcessoArtigo> AcessosArtigo { get; set; } 
    }
}
