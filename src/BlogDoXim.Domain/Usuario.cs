using BlogDoXim.Domain.Base;
using System;
using System.Collections.Generic;

namespace BlogDoXim.Domain
{
    public class Usuario : Entity
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public byte[] Foto { get; set; }
        public string Github { get; set; }

        public ICollection<Artigo> Artigos { get; set; }

    }
}
