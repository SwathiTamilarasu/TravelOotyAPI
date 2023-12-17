using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Infrastructure;
using TravelOoty.Application.Models.Blob;
using TravelOoty.Application.Models.Profile;
using TravelOoty.Infrastructure.FileUpload;

namespace TravelOoty.Infrastructure.Mail
{
    public class BlobService: IBlobService
    {        
        
        private readonly BlobServiceClient _blobServiceClient;
        public BlobService( BlobServiceClient blobServiceClient)
        {          
            _blobServiceClient = blobServiceClient;

        }
        public async Task<ImageResponse> UploadImageToBlobAsync(string blobContainerName, Stream content, string contentType, string fileName)
        {
        
            var containerClient = GetContainerClient(blobContainerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(content, new BlobHttpHeaders { ContentType = contentType });
            var imageReponse=new ImageResponse{ ImageName=fileName,ImageUri=blobClient.Uri};
            return imageReponse;
        }
        private BlobContainerClient GetContainerClient(string blobContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
            containerClient.CreateIfNotExists(PublicAccessType.Blob);
            return containerClient;
        }      
    }
}
