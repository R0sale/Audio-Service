using Domain.Enums;

namespace Application.Contracts
{
    public interface IMediaStorage
    {
        Task EnsureContainersAsync(CancellationToken ct);
        Task UploadAsync(MediaKind kind, string blobName, string contentType, Stream stream, CancellationToken ct);
        Task<bool> ExistsAsync(MediaKind kind, string blobName, CancellationToken ct);
    }
}
