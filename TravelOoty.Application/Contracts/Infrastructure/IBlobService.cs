using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Models.Profile;

namespace TravelOoty.Application.Contracts.Infrastructure
{
    public interface IBlobService
    {
        //string UploadFileToBlob(string userId, string strFileName, byte[] fileData, string fileMimeType);
        //string UploadImageToBlob(string userId, IFormFile file);

        // Task<ImageResponse> UploadImageToBlobAsync(string userId, IFormFile file, string fileName);
        Task<ImageResponse> UploadImageToBlobAsync(string blobContainerName, Stream content, string contentType, string fileName);

    }
}
