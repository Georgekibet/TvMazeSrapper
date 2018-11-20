using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvMazeScrapper.Core.Models;

namespace TvMazeScrapper.Util
{
    public class Paginator
    {
        public IEnumerable<TvShow> TvShow { get; set; }
        public int PageCount { get; set; }
        public int CurentPage { get; set; }
    }
}
