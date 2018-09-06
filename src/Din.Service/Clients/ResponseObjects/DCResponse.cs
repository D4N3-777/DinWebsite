﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Din.Service.Clients.ResponseObjects
{
    public class DCResponse
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("result")] public DCResultCollection Result { get; set; }
        [JsonProperty("error")] public object Error { get; set; }
    }

    public class DCResultCollection
    {
        [JsonProperty("torrents")] public ICollection<DCResponseItem> Items { get; set; }
    }

    public class DCResponseItem
    {
        [JsonProperty("comment")] public string Comment { get; set; }
        [JsonProperty("hash")] public string Hash { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("save_path")] public string SavePath { get; set; }
        [JsonProperty("eta")] public int Eta { get; set; }
        [JsonProperty("files")] public ICollection<DCResponseItemFile> Files { get; set; }
        [JsonProperty("file_progress")] public ICollection<double> FileProgress { get; set; }
    }

    public class DCResponseItemFile
    {
        [JsonProperty("index")] public double Index { get; set; }
        [JsonProperty("path")] public string Path { get; set; }
        [JsonProperty("offset")] public double Offset { get; set; }
        [JsonProperty("size")] public double Size { get; set; }
    }
}
