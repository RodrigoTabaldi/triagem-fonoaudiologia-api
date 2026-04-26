using System;
using System.Collections.Generic;
using System.Text;

namespace Triagem.Domain
{
    public class Pergunta
    {
        public int Id { get; set; }

        public string Texto { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        public int TriagemId { get; set; }

        public int Ordem { get; set; }
    }
}
