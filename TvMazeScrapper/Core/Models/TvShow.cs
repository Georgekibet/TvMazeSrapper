using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace TvMazeScrapper.Core.Models
{
    public class TvShow
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None), Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CastMember> Cast { get; set; }
    }
}
