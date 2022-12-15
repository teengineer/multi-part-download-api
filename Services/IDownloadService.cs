namespace Services;

using System.Net;
using Amazon.S3;
using Amazon.S3.Model;
using FastEndpoints;
using Models;

public interface IDownloadService
{
    Task<MyResponse> MultiPartDownload(MyRequest request);
}