using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TvMazeScrapper.Core.Models;
using TvMazeScrapper.Core.Repository;
using TvMazeScrapper.Util;

namespace TvMazeScrapper.Scrapper
{
    public class TvShowScrapper
    {
        private readonly ITvShowRepository _tvShowRepository;

        public TvShowScrapper(ITvShowRepository tvShowRepository)
        {
            _tvShowRepository = tvShowRepository;
        }

        public async void GetShowsFromApi()
        {
            using (HttpClient client= new HttpClient())
            {
                client.BaseAddress = new Uri(" http://api.tvmaze.com/");
                var data = await client.GetStringAsync("shows");
                List<TvShow> shows= JsonConvert.DeserializeObject<List<TvShow>>(data);
                UpdateShowCastFromApi(shows);
            }
        }

        private async void UpdateShowCastFromApi(List<TvShow> shows)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.tvmaze.com/");
               
                foreach (var tvShow in shows)
                {
                    var data = await client.GetStringAsync($"shows/{tvShow.Id}/cast");
                    var d = JsonConvert.DeserializeObject<List<CastJsonClass>>(data);
                    List<CastMember> cast = d.Distinct().Select(
                        c => new CastMember()
                        {
                          // Id = c.Person.Id,
                            ShowId = tvShow.Id,
                            BirthDay = c.Person.Birthday,
                            Name = c.Person.Name
                        }).ToList();
                    
                    tvShow.Cast = cast;
                    SaveToDb(tvShow);
                }


            }
        }

        private  void SaveToDb(TvShow show)
        {
            _tvShowRepository.Save(show); 
        }
    }

  
}
