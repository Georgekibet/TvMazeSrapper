using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvMazeScrapper.Core.Models;

namespace TvMazeScrapper.Core.Repository
{
   public interface ITvShowRepository
   {
       void Save(TvShow tvShow);

       IEnumerable<TvShow> GetAll();
       int GetCount();
       int GetLatestId();
       IEnumerable<TvShow> GetAllPaginated(int skip,int take);
       
   }
}
