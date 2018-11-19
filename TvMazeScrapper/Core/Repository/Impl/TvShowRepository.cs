using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMazeScrapper.Context;
using TvMazeScrapper.Core.Models;

namespace TvMazeScrapper.Core.Repository.Impl
{
    public class TvShowRepository :ITvShowRepository
    {
        private MazeContext _dbContext;
    
        public void Save(TvShow tvShow)
        {
          
                _dbContext.TvShows.Add(tvShow);
                _dbContext.SaveChanges();
            
        }

        public IEnumerable<TvShow> GetAll()
        {
            return _dbContext.TvShows;
        }

        public IEnumerable<TvShow> GetAllPaginated(int skip, int take)
        {
            return _dbContext.TvShows.Skip(skip).Take(take);
            
        }

     

       
     
    }
}
