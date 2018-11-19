using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvMazeScrapper.Core
{
    public class TvShow
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CastMember> Cast { get; set; }
    }
}
