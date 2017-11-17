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

        public ImageController(IImageRepository repository)
        {
            this.repository = repository;
        }


        public ViewResult List() 
        {
            return View(repository.Image);
        }
    }
}