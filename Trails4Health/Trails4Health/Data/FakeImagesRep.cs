using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class FakeImagesRep : IImageRepository
    {
        public IEnumerable<Image> Images => new List<Image>
        {
            new Image { ImageID = "1um"},
            new Image { ImageID = "2dois"}
        };
    }
}
