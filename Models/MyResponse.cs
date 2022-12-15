
namespace Models;
public class MyResponse
{
    public string Message { get; set; } = string.Empty;
    public byte[] Content { get; set; }
    public string ContentString { get; set; }
    public string ContentRange { get; set; }
    public string Key { get; set; } = string.Empty;
    public string ETag { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
}