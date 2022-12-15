using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using FastEndpoints;
using FastEndpoints.Swagger;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerDoc();
builder.Services.AddFastEndpoints();
builder.Services.AddCors();
builder.Services.AddSingleton<IAmazonS3>(_ => new AmazonS3Client(RegionEndpoint.EUWest1));

var awsCredentials = new BasicAWSCredentials(builder.Configuration["AWS:AccessKey"], builder.Configuration["AWS:SecretKey"]);
builder.Services.AddSingleton<IAmazonS3>(_ => new AmazonS3Client(awsCredentials, RegionEndpoint.EUWest1));
builder.Services.AddSingleton<IDownloadService, DownloadService>();

var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerUi3(c => c.ConfigureDefaults());
app.UseOpenApi();
app.Run();

