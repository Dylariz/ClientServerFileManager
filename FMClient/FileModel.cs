using Newtonsoft.Json;

namespace FMClient;

public class FileModel
{
    [JsonProperty ("name")]
    public string Name { get; set; } = null!;
        
    [JsonProperty ("type")]
    public string Type { get; set; } = null!;
        
    [JsonProperty ("timestamp")]
    public string Timestamp { get; set; } = null!;
        
    [JsonProperty ("size")]
    public string? Size { get; set; }
}