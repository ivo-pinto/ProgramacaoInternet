using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Health.Models;

namespace Trails4Health.Controllers
{
    public class ImageController : Controller
    {
        private IImageRepository repository;
        public int PageSize = 4;

        public ImageController(IImageRepository repository)
        {
            this.repository = repository;
        }


        public ViewResult List(int page = 1) 
        {
            return View(repository.Images.Take(PageSize));
        }
    }
}