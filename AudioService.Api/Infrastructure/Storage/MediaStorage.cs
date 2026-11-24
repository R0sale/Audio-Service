using Application.Contracts;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Domain.Enums;
using Domain.Errors;
using Domain.Shared;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Storage
{
    public sealed class MediaStorage : IMediaStorage
    {
        private readonly BlobContainerClient _audioContainerClient;
        private readonly BlobContainerClient _coverContainerClient;
        private readonly IOptions<MediaStorageOptions> _options;

        public MediaStorage(IOptions<MediaStorageOptions> options, BlobServiceClient serviceClient)
        {
            _options = options;

            _audioContainerClient = serviceClient.GetBlobContainerClient(options.Value.AudioContainerName);
            _coverContainerClient = serviceClient.GetBlobContainerClient(options.Value.CoverContainerName);
        }

        public async Task EnsureContainersAsync(CancellationToken ct)
        {
            await _audioContainerClient.CreateIfNotExistsAsync(cancellationToken: ct);
            await _coverContainerClient.CreateIfNotExistsAsync(cancellationToken: ct);
        }

        public async Task UploadAsync(MediaKind kind, string blobName, string contentType, Stream stream, CancellationToken ct)
        {
            switch (kind)
            {
                case MediaKind.Audio:
                    await _audioContainerClient.GetBlobClient(blobName).UploadAsync(stream, new BlobUploadOptions
                    {
                        HttpHeaders = new BlobHttpHeaders { ContentType = contentType }
                    }, ct);
                    break;
                case MediaKind.Cover:
                    await _coverContainerClient.GetBlobClient(blobName).UploadAsync(stream, new BlobUploadOptions
                    {
                        HttpHeaders = new BlobHttpHeaders { ContentType = contentType }
                    }, ct);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"The media king: {kind} is not supported by our application");
            }
        }

        public async Task<bool> ExistsAsync(MediaKind kind, string blobName, CancellationToken ct)
        {
            switch (kind)
            {
                case MediaKind.Audio:
                    return await _audioContainerClient.GetBlobClient(blobName).ExistsAsync(ct);
                case MediaKind.Cover:
                    return await _coverContainerClient.GetBlobClient(blobName).ExistsAsync(ct);
                default:
                    throw new ArgumentOutOfRangeException($"The media king: {kind} is not supported by our application");
            }
        }

        public string GetFullUrl(MediaKind kind, string blobName)
        {
            switch (kind)
            {
                case MediaKind.Audio:
                    return _audioContainerClient.GetBlobClient(blobName).GenerateSasUri(Azure.Storage.Sas.BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddMinutes(_options.Value.UrlExpireInMinutes)).ToString();
                case MediaKind.Cover:
                    return _coverContainerClient.GetBlobClient(blobName).GenerateSasUri(Azure.Storage.Sas.BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddMinutes(_options.Value.UrlExpireInMinutes)).ToString();
                default:
                    throw new ArgumentOutOfRangeException($"The media king: {kind} is not supported by our application");
            }
        }
    }
}
