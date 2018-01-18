using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class TrilhoViewModel
    {



       // public int TrilhoId { get; set; }


        public string Nome { get; set; }

      
      
        public string Inicio { get; set; }



        
       
        public string Fim { get; set; }

        
        public int AltitudeMax { get; set; }

      
        public int AltitudeMin { get; set; }


       
        public string Descricao { get; set; }

        
       
        public int InteresseHistorico { get; set; }

        
        
        public int BelezaPai { get; set; }

        

        public int GrauDificuldade { get; set; } 

     
        public int DuracaoMedia { get; set; }

    }
}

