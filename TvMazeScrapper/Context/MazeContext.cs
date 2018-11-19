using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMazeScrapper.Core;
using TvMazeScrapper.Core.Models;

namespace TvMazeScrapper.Context
{
    public class MazeContext : DbContext
    {
        public MazeContext(DbContextOptions options) : base(options)
        {
            
        }
      public   DbSet<TvShow> TvShows { get; set; }

       public  DbSet<CastMember> CastMembers { get; set; }

    }
}
