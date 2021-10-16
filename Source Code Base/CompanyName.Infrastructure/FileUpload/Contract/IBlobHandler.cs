using Amazon.S3.Model;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AspireSystems.Infrastructure.FileUpload.Contract
{
    /// <summary>
    /// Represents the contract for blob handler
    /// </summary>
    public interface IBlobHandler
    {
        Task Upload(byte[] imageByteArray, string fileName);
        Task<string> Download(string fileName);
        void DeleteFiles(string RelativePath, string folderPath);
        Task CreateIfBucketNotExistsAsync();
        Task<Stream> GetFileStream(string fileName);
        Task<List<S3Object>> ListBucketObjects(string bucketName);
    }
}
