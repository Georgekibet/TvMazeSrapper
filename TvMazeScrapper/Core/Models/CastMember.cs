using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvMazeScrapper.Core.Models
{
    public class CastMember
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public int CastMemberId { get; set; }
        public int ShowId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
