using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMazeScrapper.Core;

namespace TvMazeScrapper.Context
{
    public class MazeContext : DbContext
    {
        public MazeContext(DbContextOptions options) : base(options)
        {
            
        }
         DbSet<TvShow> TvShows { get; set; }

         DbSet<CastMember> CastMembers { get; set; }

    }
}
