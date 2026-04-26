using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Triagem.Domain
{
   public class CalculadoraTriagem
    {
    

            public string CalcularRisco(List<Resposta> respostas)
        {
            int pontuacao = respostas.Count(r => r.Valor == true);


            string risco;

            if (pontuacao <= 5)
                risco = "Baixo";
            else if (pontuacao <= 15)
                risco = "Moderado";
            else
                risco = "Alto";

            return risco;




        }
        }

    }




