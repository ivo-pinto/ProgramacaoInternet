using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class SelecionarTrilhosViewModel
    {
        public IEnumerable<Trilho> Trilhos { get; set; }
        public IEnumerable<string> ValoresSelecionados { get; set; }

    }
}
