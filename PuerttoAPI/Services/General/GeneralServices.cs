using Core.Puertto.DTOs.General;
using Core.Puertto.Exceptions;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using PuerttoAPI.Extensions;
using PuerttoAPI.Interfaces;
using System.Net;

namespace PuerttoAPI.Services.General
{
    public class GeneralServices : IGeneralServices
    {
        private readonly IConfiguration _configuration;

        public GeneralServices(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        public async Task<List<BannerIndex>> GetBannerByIndex(bool isSingIn)
        {
            try
            {
                var listBanner = new List<BannerIndex>();
                var containerName = (isSingIn)? _configuration.GetValue<string>("AzureStorage:Multimedia:ContainerNameSI") : _configuration.GetValue<string>("AzureStorage:Multimedia:ContainerName");
                var urisBlob = await GetBlobFiles(containerName);
                urisBlob = urisBlob.OrderBy(x => x.AbsolutePath).ToList();
                var count = 0;
                foreach (var item in urisBlob)
                {
                    listBanner.Add(new BannerIndex()
                    {
                        id = count,
                        url = item
                    });
                    count++;
                }
               
                return listBanner;
            }
            catch (Exception ex)
            {
                var friendlyMessage = "Lamentamos los inconvenientes, por favor intente de nuevo.";
                var httpStatusCode = (int)HttpStatusCode.InternalServerError;
                throw new HttpException(ex.Message, friendlyMessage, httpStatusCode, ex.InnerException);
            }
           
        }


        private async Task<List<Uri>> GetBlobFiles(string containerName)
        {
            var uris = new List<Uri>();           
            var container = GetCloudBlobClient().GetContainerReference(containerName);
            if (!await container.ExistsAsync()) await container.CreateAsync();
            BlobContinuationToken blobContinuationToken = null;
            do
            {
                var resultSegment = await container.ListBlobsSegmentedAsync(null, blobContinuationToken);

                // Get the value of the continuation token returned by the listing call.
                blobContinuationToken = resultSegment.ContinuationToken;
                foreach (IListBlobItem item in resultSegment.Results) { uris.Add(item.Uri);}
            }

            while (blobContinuationToken != null); // Loop while the continuation token is not null.
            return uris;
        }


        private CloudBlobClient GetCloudBlobClient()
        {
            var accountName = _configuration.GetValue<string>("AzureStorage:AccountName");
            var accountKey = _configuration.GetValue<string>("AzureStorage:Key");
            var azureStorageStringConnection = $"DefaultEndpointsProtocol=https;AccountName={accountName};AccountKey={accountKey};EndpointSuffix=core.windows.net";
            var cloudStorageAccount = CloudStorageAccount.Parse(azureStorageStringConnection);
            var blobClient = cloudStorageAccount.CreateCloudBlobClient();
            return blobClient;
        }
    }
}
