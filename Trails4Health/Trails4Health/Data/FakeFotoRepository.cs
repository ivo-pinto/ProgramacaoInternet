using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public class FakeFotoRepository : IFotoRepository{
            public IEnumerable<Foto> Fotos => new List<Foto> {
                new Foto {  ImageMimeType = "Teste1" },
                new Foto {  ImageMimeType = "Teste2" },
                new Foto {  ImageMimeType = "Teste3" }
            };
    }
}
