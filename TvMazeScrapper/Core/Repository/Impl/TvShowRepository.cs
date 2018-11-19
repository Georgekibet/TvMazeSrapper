using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMazeScrapper.Context;

namespace TvMazeScrapper.Core.Repository.Impl
{
    public class TvShowRepository :ITvShowRepository
    {
        public void Save(TvShow tvShow)
        {
            using (var ctx= new MazeContext(new DbContextOptions<MazeContext>()))
            {
                ctx.TvShows.Add(tvShow);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<TvShow> GetAll()
        {
            using (var ctx = new MazeContext(new DbContextOptions<MazeContext>()))
            {
                return ctx.TvShows;
            }
        }

        public IEnumerable<TvShow> GetAllPaginated(int skip, int take)
        {
            using (var ctx = new MazeContext(new DbContextOptions<MazeContext>()))
            {
                return ctx.TvShows.Skip(skip).Take(take);
            }
        }
    }
}
