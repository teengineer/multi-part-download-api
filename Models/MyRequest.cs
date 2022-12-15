
namespace Models;
public class MyRequest
{

    public string AccountId { get; set; }
    public string BucketName { get; set; }
    public string Key { get; set; }

    public long StartRange { get; set; }
    public long EndRange { get; set; }
}