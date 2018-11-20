using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMazeScrapper.Context;
using TvMazeScrapper.Core.Models;
using TvMazeScrapper.Util;

namespace TvMazeScrapper.Core.Repository.Impl
{
    public class TvShowRepository :ITvShowRepository
    {
        private MazeContext _dbContext;


        public TvShowRepository(MazeContext dbContext)
        {
           _dbContext = dbContext;
        }
    

        public void Save(TvShow tvShow)
        {
            var item = _dbContext.TvShows.FirstOrDefault(i => i.Id == tvShow.Id);
            if (item == null)
            {
                _dbContext.TvShows.AddOrUpdate(tvShow);
            }

            _dbContext.SaveChanges();
            
        }


        public IEnumerable<TvShow> GetAll()
        {
            return _dbContext.TvShows;
        }

        public int GetCount()
        {
            return _dbContext.TvShows.Count();
        }

        public int GetLatestId()
        {
            return _dbContext.TvShows.Max(s => s.Id);
           
        }

        public IEnumerable<TvShow> GetAllPaginated(int skip, int take)
        {
            var tvsows = _dbContext.TvShows.Skip(skip).Take(take).Include(show => show.Cast);
            foreach(var show in tvsows)
            {
                show.Cast = show.Cast.OrderByDescending(m =>m.BirthDay).ToList();
            }
            return tvsows;
        }

     

       
     
    }
}
