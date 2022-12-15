
namespace Endpoints;

using System.Net;
using Amazon.S3;
using Amazon.S3.Model;
using FastEndpoints;
using Models;
using Services;

public class MultipartDownload : Endpoint<MyRequest, MyResponse>
{

    private readonly IDownloadService _service;
    public MultipartDownload(IDownloadService service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/multipart/download");
        AllowAnonymous();
    }

    public override async Task HandleAsync(MyRequest r, CancellationToken ct)
    {
        var result = await _service.MultiPartDownload(r);
        await SendAsync(result, HttpStatusCode.OK.GetHashCode(), ct);
    }
}