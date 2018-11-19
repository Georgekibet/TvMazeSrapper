using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TvMazeScrapper.Util
{
    public  class CastJsonClass
    {
        [JsonProperty("person", NullValueHandling = NullValueHandling.Ignore)]
        public Person Person { get; set; }

        [JsonProperty("character", NullValueHandling = NullValueHandling.Ignore)]
        public Character Character { get; set; }

        [JsonProperty("self", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Self { get; set; }

        [JsonProperty("voice", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Voice { get; set; }
    }

  
}
