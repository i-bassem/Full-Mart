using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]

        public string UploadImage( IFormFile _File)
        {

            try
            {

                // 1 )   Get Directory
                string FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/Files/Images" ;

                // 2)  // Get File Name
                string FileName = Guid.NewGuid() + Path.GetFileName(_File.FileName);

                // 3)  // Merge Path with File Name
                string FinalPath = Path.Combine(FolderPath, FileName);

                // 4)  // Save File As Streams "Data Overtime"
                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    _File.CopyTo(Stream);
                }

                return FinalPath;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        [HttpGet("{imageId}")]
        public ActionResult<string> GetImage(Guid imageId)
        {
            var fileName = $"{imageId}.jpg";
            var path = Path.Combine(_webHostEnvironment.WebRootPath, fileName);
            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }

            var imageBytes = System.IO.File.ReadAllBytes(path);
            var base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }


    }
}
