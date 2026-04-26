using System;
using System.Collections.Generic;
using System.Text;

namespace Triagem.Domain
{
    public class Triagem
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public List<Pergunta> Pergunta { get; set; } = new List<Pergunta>();
    }
}

