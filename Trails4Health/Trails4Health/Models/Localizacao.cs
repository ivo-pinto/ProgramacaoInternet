using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Localizacao
    {
        public int IdLocalizacao;
        public string Nome;
        public string Coordenadas; //mudar para tipo GeoCoordinate

        public Localizacao(int IdLocalizacao, string Nome, string Coordenadas)
        {
            this.IdLocalizacao = IdLocalizacao;
            this.Nome = Nome;
            this.Coordenadas = Coordenadas;
        }

    }
}
