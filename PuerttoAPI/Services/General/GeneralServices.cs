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

        public async Task<List<BannerIndex>> GetBannerByIndex(bool isSingIn, bool isMovil)
        {
            try
            {
                var listBanner = new List<BannerIndex>();
                var urisBlob = new List<Uri>();
                if (isMovil)
                {
                    var containerName = (isSingIn) ? _configuration.GetValue<string>("AzureStorage:Multimedia:ContainerNameMI") : _configuration.GetValue<string>("AzureStorage:Multimedia:ContainerNameMSI");
                    urisBlob = await GetBlobFiles(containerName);
                }
                else
                {
                    var containerName = (isSingIn) ? _configuration.GetValue<string>("AzureStorage:Multimedia:ContainerNameSI") : _configuration.GetValue<string>("AzureStorage:Multimedia:ContainerName");
                    urisBlob = await GetBlobFiles(containerName);
                }
               
                urisBlob = urisBlob.OrderBy(x => x.AbsolutePath).ToList();
                
                var count = 0;
                foreach (var item in urisBlob)
                {
                    listBanner.Add(new BannerIndex()
                    {
                        id = count,
                        url = item,
                        link =(isSingIn)? string.Empty : "/usuarios/adn-registrar"
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

        public async Task<List<BannerCruz>> GetBannerCruzIndex()
        {
            try
            {
                var styleBanner = "card-title d-xl-block d-md-block d-xxl-block";
                Random rand = new Random();
                var listBanner = new List<BannerCruz>();
                var containerName = _configuration.GetValue<string>("AzureStorage:Multimedia:ContainerNameC");
                var urisBlob = await GetBlobFiles(containerName);
                urisBlob = urisBlob.OrderBy(x => rand.Next()).Take(4).ToList();
                var count = 0;

                foreach (var item in urisBlob)
                {
                    listBanner.Add(new BannerCruz()
                    {
                        id = count,
                        imgRuta = item
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


        private async Task<List<MetadataBlobImg>> GetBlobFilesMetadata(string containerName)
        {
            var Metadatas = new List<MetadataBlobImg>();
            var container = GetCloudBlobClient().GetContainerReference(containerName);
            if (!await container.ExistsAsync()) await container.CreateAsync();
            BlobContinuationToken blobContinuationToken = null;
            do
            {
                var resultSegment = await container.ListBlobsSegmentedAsync(null, blobContinuationToken);
                // Get the value of the continuation token returned by the listing call.
                blobContinuationToken = resultSegment.ContinuationToken;

                foreach (IListBlobItem item in resultSegment.Results) {
                    var metadata = new MetadataBlobImg();
                    

                    if (item is CloudBlockBlob blob)
                    {
                        //the new package supports syncronous method
                        await blob.FetchAttributesAsync();
                       
                        foreach (var metadataItem in blob.Metadata)
                        {
                            switch(metadataItem.Key)
                            {
                                case "title":
                                    metadata.Title = Uri.UnescapeDataString(metadataItem.Value);
                                    break;

                                case "color":
                                    metadata.Color = metadataItem.Value;
                                    break;
                            }
                        }
                    }     
                    metadata.Uri = item.Uri;
                    Metadatas.Add(metadata);

                }

            }

            while (blobContinuationToken != null); // Loop while the continuation token is not null.
            return Metadatas;
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
