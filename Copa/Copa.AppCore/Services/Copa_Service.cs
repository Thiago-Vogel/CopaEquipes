using Copa.AppCore.Implementations;
using Copa.AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Copa.AppCore.Services
{
    public class Copa_Service:ICopa_Service
    {
        public IEnumerable<Equipe> GerarCopa(IEnumerable<Equipe> equipes)
        {
            List<Equipe> resultado = new List<Equipe>();
            var ordenadas = equipes.OrderBy(e => e.Nome).ToList();
            List<Equipe> vencedoras = new List<Equipe>();
            int rodadas = ordenadas.Count() / 2;

            //Partidas iniciais
            for (int i = 0; i < rodadas; i++)
            {
                var equipe_a = ordenadas[i];
                var equipe_b = ordenadas[(ordenadas.Count() - 1) - i];
                vencedoras.Add(QuemVenceu(equipe_a, equipe_b));
            }
            List<Equipe> finalistas = new List<Equipe>();
            
            //Semifinais
            while (finalistas.Count() != 2)
            {
                finalistas = Semifinais(vencedoras);
                vencedoras = finalistas;
            }

            //Final
            var campea = QuemVenceu(finalistas.FirstOrDefault(), finalistas.LastOrDefault());
            var segundona = finalistas.Where(e => e.Id != campea.Id).FirstOrDefault();
            resultado.Add(campea);
            resultado.Add(segundona);
            
            return resultado;
        }

        private List<Equipe> Semifinais(List<Equipe> vencedoras)
        {
            List<Equipe> finalistas = new List<Equipe>();
            int rodadas = vencedoras.Count() / 2;
            for(int i = 0;i <= rodadas; i++)
            {
                var equipe_a = vencedoras[i];
                var equipe_b = vencedoras[i + 1];
                i++;
                finalistas.Add(QuemVenceu(equipe_a, equipe_b));
            }
            return finalistas;
        }

        private Equipe QuemVenceu(Equipe a, Equipe b)
        {
            var aGanhou = (a.Gols > b.Gols);
            var bGanhou = (b.Gols > a.Gols);
            var empate = (!aGanhou && !bGanhou);
            if (empate)
            {
                List<Equipe> ordena = new List<Equipe>();
                ordena.Add(a);
                ordena.Add(b);
                return ordena.OrderBy(e => e.Nome).FirstOrDefault();
            }
            Equipe vencedora = aGanhou ? a : b;
            return vencedora;
        }
    }
}
