using System.Net;
using Amazon.S3;
using Amazon.S3.Model;
using Models;

namespace Services;
public class DownloadService : IDownloadService
{
    private readonly IAmazonS3 _s3Client;
    public DownloadService(IAmazonS3 s3Client)
    {
        _s3Client = s3Client;
    }

    public async Task<Models.MyResponse> MultiPartDownload(MyRequest request)
    {
        try
        {
            var range = new ByteRange(request.StartRange, request.EndRange);
            var b3MultipartDownload = new GetObjectRequest
            {
                BucketName = request.BucketName,
                Key = request.Key,
                ByteRange = range
            };
            var response = await _s3Client.GetObjectAsync(b3MultipartDownload);
            if (response.HttpStatusCode != HttpStatusCode.PartialContent)
                response = null;

            using (MemoryStream ms = new MemoryStream())
            {
                response.ResponseStream.CopyTo(ms);
                var d = ms.ToArray();
                Console.WriteLine("ContentRange: {0}", ms.ToArray().Length);
                return new Models.MyResponse
                {
                    IsSuccess = true,
                    Message = "Başarılı",
                    Key = response.Key,
                    ContentRange = response.ContentRange,
                    ContentString = Convert.ToBase64String(ms.ToArray()),
                    Content = ms.ToArray()
                };
            }
        }
        catch (Exception e)
        {
            return null;
        }
    }
}