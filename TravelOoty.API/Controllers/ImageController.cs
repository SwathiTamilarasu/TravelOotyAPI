using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using TravelOoty.Infrastructure.FileUpload;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        IWebHostEnvironment _env;
        [HttpPost]
        public IActionResult UploadImage(IFormFile Files)
        {
            //var uploads = Path.Combine(_env.WebRootPath, "uploads");
            //var fileName = Path.GetFileName(Files.FileName);
            //var fileStream = new FileStream(Path.Combine(uploads, Files.FileName), FileMode.Create);
            string mimeType = Files.ContentType;
            byte[] fileData = new byte[Files.Length];

            BlobStorageService objBlobService = new BlobStorageService();

           var result = objBlobService.UploadFileToBlob(Files.FileName, fileData, mimeType,"me");
            return Ok(result);
        }
    }
}
