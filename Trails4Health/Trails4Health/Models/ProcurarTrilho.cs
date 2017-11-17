using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trails4Health.Models
{
    public class ProcurarTrilho : Controller
    {
        public string Localizacao { get; set; }
        public string Dificuldade { get; set; }
        public string Extencao { get; set; }
        public string Forma { get; set; }
        public string Image { get; set; }
    }
}
