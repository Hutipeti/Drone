using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MezogazdasagiDron.Services
{
    public class BlobStorageService
    {
        private static readonly string testImagePath = @"C:\Projects\Drone\drone-test.jpeg";

        public BlobStorageService()
        {

        }

        public static void Upload(string userId, Guid farmId)
        {
            CloudBlobContainer container;
            CloudStorageAccount storageAccount;
            var connectionString = ConfigurationManager.AppSettings["blobStorageConnectionString"];

            if (CloudStorageAccount.TryParse(connectionString, out storageAccount))
            {
                try
                {
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    container = blobClient.GetContainerReference($"{userId}-{farmId}");
                    container.CreateIfNotExists();

                    var permissions = new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Off
                    };
                    container.SetPermissions(permissions);

                    CloudBlockBlob blockBlob = container.GetBlockBlobReference("drone-test");
                    using (var fileStream = System.IO.File.OpenRead(testImagePath))
                    {
                        blockBlob.UploadFromStream(fileStream);
                    }
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}