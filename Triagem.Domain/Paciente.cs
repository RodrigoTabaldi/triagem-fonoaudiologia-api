using System;
using System.Collections.Generic;
using System.Text;

namespace Triagem.Domain
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Sexo { get; set; } = string.Empty;

        public string Observacao { get; set; } = string.Empty;

    }
}
