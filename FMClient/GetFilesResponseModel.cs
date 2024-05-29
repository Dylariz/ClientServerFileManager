using System.Collections.Generic;
using Newtonsoft.Json;

namespace FMClient;

public class GetFilesResponseModel
{
    [JsonProperty ("path")]
    public string Path { get; set; } = null!;
        
    [JsonProperty ("count")]
    public int Count { get; set; }
        
    [JsonProperty ("objects")]
    public List<FileModel> Objects { get; set; } = null!;
}