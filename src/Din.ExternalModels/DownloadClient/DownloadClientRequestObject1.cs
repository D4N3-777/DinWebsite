﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Din.ExternalModels.DownloadClient
{
    public class DownloadClientRequestObject1
    {
        public DownloadClientRequestObject1()
        {
        }

        public DownloadClientRequestObject1(string method, List<string> paramaters, int id)
        {
            Method = method;
            Params = paramaters;
            Id = id;
        }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public List<string> Params { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}