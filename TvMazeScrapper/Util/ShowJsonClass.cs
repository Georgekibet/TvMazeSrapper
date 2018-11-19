using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TvMazeScrapper.Util
{
    public class ShowJsonClass

    {
        
        public int Id { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Genres { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("runtime", NullValueHandling = NullValueHandling.Ignore)]
        public long? Runtime { get; set; }

        [JsonProperty("premiered", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Premiered { get; set; }

        [JsonProperty("officialSite", NullValueHandling = NullValueHandling.Ignore)]
        public Uri OfficialSite { get; set; }

        [JsonProperty("schedule", NullValueHandling = NullValueHandling.Ignore)]
        public Schedule Schedule { get; set; }

        [JsonProperty("rating", NullValueHandling = NullValueHandling.Ignore)]
        public Rating Rating { get; set; }

        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public long? Weight { get; set; }

        [JsonProperty("network", NullValueHandling = NullValueHandling.Ignore)]
        public Network Network { get; set; }

        [JsonProperty("webChannel")]
        public object WebChannel { get; set; }

        [JsonProperty("externals", NullValueHandling = NullValueHandling.Ignore)]
        public Externals Externals { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Image Image { get; set; }

        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public long? Updated { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Ignore)]
        public WelcomeLinks Links { get; set; }

        [JsonProperty("_embedded", NullValueHandling = NullValueHandling.Ignore)]
        public Embedded Embedded { get; set; }
    }

    public class Embedded
    {
        [JsonProperty("cast", NullValueHandling = NullValueHandling.Ignore)]
        public List<Cast> Cast { get; set; }
    }

    public class Cast
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

    public  class Character
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Image Image { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Ignore)]
        public CharacterLinks Links { get; set; }
    }

    public class Image
    {
        [JsonProperty("medium", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Medium { get; set; }

        [JsonProperty("original", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Original { get; set; }
    }

    public class CharacterLinks
    {
        [JsonProperty("self", NullValueHandling = NullValueHandling.Ignore)]
        public Previousepisode Self { get; set; }
    }

    public class Previousepisode
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Href { get; set; }
    }

    public class Person
    {
    
        public int Id { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public Country Country { get; set; }

        [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Birthday { get; set; }

        [JsonProperty("deathday")]
        public object Deathday { get; set; }

        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public string Gender { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Image Image { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Ignore)]
        public CharacterLinks Links { get; set; }
    }

    public  class Country
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; set; }
    }

    public class Externals
    {
        [JsonProperty("tvrage", NullValueHandling = NullValueHandling.Ignore)]
        public long? Tvrage { get; set; }

        [JsonProperty("thetvdb", NullValueHandling = NullValueHandling.Ignore)]
        public long? Thetvdb { get; set; }

        [JsonProperty("imdb", NullValueHandling = NullValueHandling.Ignore)]
        public string Imdb { get; set; }
    }

    public class WelcomeLinks
    {
        [JsonProperty("self", NullValueHandling = NullValueHandling.Ignore)]
        public Previousepisode Self { get; set; }

        [JsonProperty("previousepisode", NullValueHandling = NullValueHandling.Ignore)]
        public Previousepisode Previousepisode { get; set; }
    }

    public class Network
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public Country Country { get; set; }
    }

    public class Rating
    {
        [JsonProperty("average", NullValueHandling = NullValueHandling.Ignore)]
        public double? Average { get; set; }
    }

    public class Schedule
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public string Time { get; set; }

        [JsonProperty("days", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Days { get; set; }
    }
}
