using System;

namespace TvMazeScrapper.Core.Models
{
    public class CastMember
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
