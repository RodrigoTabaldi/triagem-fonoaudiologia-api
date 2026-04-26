using System;
using System.Collections.Generic;
using System.Text;

namespace Triagem.Domain
{
    public class TriagemRequest
    {
        public int PacientId { get; set; }
        public List<Resposta> Respostas { get; set; } = new List<Resposta>();
    }
}
