using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class FakeImagesRep : IImageRepository
    {
        public IEnumerable<Foto> Images => new List<Foto>
        {
            new Foto { ImageID = "1um"},
            new Foto { ImageID = "2dois"}
        };
    }
}
