using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvMazeScrapper.Core.Repository
{
   public interface ITvShowRepository
   {
       void Save(TvShow tvShow);

       IEnumerable<TvShow> GetAll();
       IEnumerable<TvShow> GetAllPaginated(int skip,int take);

   }
}
