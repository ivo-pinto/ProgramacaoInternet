using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class FotoDetailsViewModel
    {
        public Foto Foto { get; set; }
        public IEnumerable<Trilho> TrilhosFoto { get; set; }
    }
}
