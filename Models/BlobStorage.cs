using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IoTDeviceInfoVisualisationApp.Models
{
    public class BlobStorage : IStorage
    {
        private readonly AzureStorageConfig storageConfig;
        public BlobStorage(IOptions<AzureStorageConfig> storageConfig)
        {
            this.storageConfig = storageConfig.Value;
        }
        public Task<Stream> Load(string name)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConfig.ConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(storageConfig.FileContainerName);
            return container.GetBlobReference(name).OpenReadAsync();
        }
    }
}
