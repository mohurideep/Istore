using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace IStore.Web.Controllers
{
    public class SharedController : Controller
    {

        private readonly IWebHostEnvironment _environment;
        public SharedController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile files)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(files.FileName);
            var saveImg = Path.Combine(_environment.WebRootPath, "images", fileName);

            if (files != null)
            {
                if (files.Length > 0)
                {
                    using(var uploadImage=new FileStream(saveImg,FileMode.Create))
                    {
                        files.CopyTo(uploadImage);                        
                    }
                }
                return new ObjectResult(new { status = "success", imageURL = string.Format("/images/{0}",fileName) });
            }
            return new ObjectResult(new { status = "fail" });
        }
    }
}
