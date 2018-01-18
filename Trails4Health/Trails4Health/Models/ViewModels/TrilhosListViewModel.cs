using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class TrilhosListViewModel
    {
        public IEnumerable<Trilho> Trilhos { get; set; }
        
        public int TrilhoId1 { get; set; }
        public int TrilhoId2 { get; set; }

        

    }
}
