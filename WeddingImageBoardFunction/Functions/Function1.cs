using System;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Http = Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For Azure Blob Storage
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using System.Threading.Tasks;

namespace WeddingImageBoardFunction.Functions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(Http.AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string connectionString = "DefaultEndpointsProtocol=https;AccountName=weddingphotoscr;AccountKey=iakIFfhS+c/FeR4Ey5eohZM9yvzDWAWV4JgloUqDbETZBq9Cuacclg4x/t8FuUBnkJjuLUiuk622+ASttzw2Pg==;EndpointSuffix=core.windows.net"; // Should be stored securely!

            // Define your containerName here
            string containerName = "weddingphotoscontainer"; // Replace with your actual container name

            string blobName = System.Guid.NewGuid().ToString(); // Generate a new unique file name

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerClient.Name,
                BlobName = blobClient.Name,
                Resource = "b"
            };
            sasBuilder.StartsOn = DateTimeOffset.UtcNow;
            sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
            sasBuilder.SetPermissions(BlobSasPermissions.Write);

            Uri sasUri = blobClient.GenerateSasUri(sasBuilder);

            return new OkObjectResult(sasUri);
        }
    }
}
