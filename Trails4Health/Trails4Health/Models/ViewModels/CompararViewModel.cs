using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class CompararViewModel
    {
        public IEnumerable<Trilho> Trilho1 { get; set; }
        public IEnumerable<Trilho> Trilho2 { get; set; }
    }
}
