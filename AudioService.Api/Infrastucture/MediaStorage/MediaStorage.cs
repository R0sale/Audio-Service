using Application.Contracts;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.MediaStorage
{
    public sealed class MediaStorage : IMediaStorage
    {
        private readonly BlobContainerClient _audioContainerClient;
        private readonly BlobContainerClient _coverContainerClient;

        public MediaStorage(IOptions<MediaStorageOptions> options, BlobServiceClient serviceClient)
        {
            _audioContainerClient = serviceClient.GetBlobContainerClient(options.Value.AudioContainerName);
            
            _coverContainerClient = serviceClient.GetBlobContainerClient(options.Value.CoverContainerName);
            
        }

        public async Task EnsureContainersAsync()
        {
            await _audioContainerClient.CreateIfNotExistsAsync();
            await _coverContainerClient.CreateIfNotExistsAsync();
        }
    }
}
