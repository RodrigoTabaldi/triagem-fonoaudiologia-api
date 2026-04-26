using System;
using System.Collections.Generic;
using System.Text;

namespace Triagem.Domain
{
  public class AplicacaoTriagem
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public DateTime Data { get; set; }
        public int Pontuacao { get; set; }
        public string Risco { get; set; } = string.Empty;

    }
}
