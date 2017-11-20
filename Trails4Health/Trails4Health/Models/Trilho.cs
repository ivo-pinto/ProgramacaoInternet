using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Trilho
    {
        public string TrihoID { get; set; }
        public string Nome { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }//nota:procurar variavel cordgps
        public int AltitudeMax { get; set; }
        public int AltitudeMin { get; set; }
        public string Descricao { get; set; }
        public string IDutilizador { get; set; }
        public string IDDificuldade { get; set; }
        public int InteresseHistorico { get; set; }
        public int BelezaPai { get; set; }
    }
}
