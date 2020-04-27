using BlogDoXim.Domain.Base;
using System;
using System.Collections.Generic;

namespace BlogDoXim.Domain
{
    public class Categoria : Entity
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public byte[] Imagem { get; set; }
        public DateTime DataCadastro { get; set; }

        public ICollection<Artigo> Artigos { get; set; }
    }
}
