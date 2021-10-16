using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspireSystems.Infrastructure.FileUpload.Contract;
using AspireSystems.Infrastructure.Models;

namespace AspireSystems.Infrastructure.FileUpload
{
    public class BlobHandler : IBlobHandler
    {
        #region Members
        /// <summary>
        /// AppSettings
        /// </summary>
        private readonly AppSettings config;
        #endregion

        #region Constructor
        /// <summary>
        /// BlobHandler Constructor
        /// </summary>
        /// <param name="appSettings"></param>
        public BlobHandler(IOptions<AppSettings> appSettings)
        {
            config = appSettings.Value;

        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Uploads file to Amazon S3 Client
        /// </summary>
        /// <param name="imageByteArray"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task Upload(byte[] imageByteArray, string fileName)
        {
            IAmazonS3 amazonS3Client;
            using (amazonS3Client = new AmazonS3Client(config.awsAccessKey, config.awsSecretKey, RegionEndpoint.GetBySystemName(config.regionEndPoint)))
            {
                var request = new PutObjectRequest
                {
                    BucketName = config.bucketName,
                    Key = fileName
                };
                using (var ms = new MemoryStream(imageByteArray))
                {
                    request.InputStream = ms;
                    await amazonS3Client.PutObjectAsync(request);
                }
            }
        }

        /// <summary>
        /// Downloads a file from Amazon S3 Client
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> Download(string fileName)
        {
            await Task.Yield();
            IAmazonS3 amazonS3Client;
            using (amazonS3Client = new AmazonS3Client(config.awsAccessKey, config.awsSecretKey, RegionEndpoint.GetBySystemName(config.regionEndPoint)))
            {
                var expiryUrlRequest = new GetPreSignedUrlRequest()
                {
                    BucketName = config.bucketName,
                    Key = fileName,
                    Expires = DateTime.Now.AddDays(3)
                };
                string url = amazonS3Client.GetPreSignedURL(expiryUrlRequest);
                return url;
            }
        }

        public async Task<Stream> GetFileStream(string fileName)
        {
            try
            {
                IAmazonS3 amazonS3Client;
                using (amazonS3Client = new AmazonS3Client(config.awsAccessKey, config.awsSecretKey, RegionEndpoint.GetBySystemName(config.regionEndPoint)))
                {
                    GetObjectResponse response = await amazonS3Client.GetObjectAsync(config.bucketName, fileName);
                    MemoryStream memoryStream = new MemoryStream();
                    using (Stream responseStream = response.ResponseStream)
                    {
                        responseStream.CopyTo(memoryStream);
                    }
                    return memoryStream;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Deletes a file and folder from mentioned path
        /// </summary>
        /// <param name="RelativePath"></param>
        /// <param name="folderPath"></param>
        public void DeleteFiles(string RelativePath, string folderPath)
        {
            var fileName = RelativePath;
            if (!string.IsNullOrEmpty(fileName))
            {
                var filePath = Path.Combine(folderPath, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
        }

        /// <summary>
        /// Creates a S3 bucket if it does not exists.
        /// </summary>
        /// <returns></returns>
        public async Task CreateIfBucketNotExistsAsync()
        {
            IAmazonS3 amazonS3Client;
            using (amazonS3Client = new AmazonS3Client(config.awsAccessKey, config.awsSecretKey, RegionEndpoint.GetBySystemName(config.regionEndPoint)))
            {
                if (!(await AmazonS3Util.DoesS3BucketExistAsync(amazonS3Client, config.bucketName)))
                {
                    var putBucketRequest = new PutBucketRequest
                    {
                        BucketName = config.bucketName,
                        UseClientRegion = true
                    };
                   await amazonS3Client.PutBucketAsync(putBucketRequest);
                }
            }
        }

        public async Task<List<S3Object>> ListBucketObjects(string bucketName)
        {
            ListObjectsResponse listResponse;
            List<S3Object> s3Objects = new List<S3Object>();
            try
            {
                IAmazonS3 amazonS3Client;
                using (amazonS3Client = new AmazonS3Client(config.awsAccessKey, config.awsSecretKey, RegionEndpoint.GetBySystemName(config.regionEndPoint)))
                {
                    ListObjectsRequest listRequest = new ListObjectsRequest
                    {
                        BucketName = config.bucketName,
                        Prefix = bucketName
                    };
                    do
                    {
                        listResponse = await amazonS3Client.ListObjectsAsync(listRequest);
                        if (listResponse.S3Objects.Any())
                        {
                            s3Objects.AddRange(listResponse.S3Objects);
                        }
                        listRequest.Marker = listResponse.NextMarker;
                    } while (listResponse.IsTruncated);
                    return s3Objects;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
