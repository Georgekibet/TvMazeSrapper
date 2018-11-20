using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public void GetShowsFromRemoteApi()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" http://api.tvmaze.com/");
                var count = 0;
                if (_tvShowRepository.GetCount() > 0)
                {
                    var latestid = _tvShowRepository.GetLatestId();
                    count = (int) Math.Floor((decimal) (latestid / 250));
                }
                var data = "";

                do
                {
                    data = client.GetStringAsync($"shows?page={count}").Result;
                    var shows = JsonConvert.DeserializeObject<List<TvShow>>(data);
                    UpdateShowCastFromApi(shows);
                    count++;
                } while (data != string.Empty);
            }
        }


        private void UpdateShowCastFromApi(List<TvShow> shows)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.tvmaze.com/");

                foreach (var tvShow in shows)
                {
                    var data = client.GetStringAsync($"shows/{tvShow.Id}/cast").Result;
                    var d = JsonConvert.DeserializeObject<List<CastJsonClass>>(data);
                    var cast = d.Distinct().Select(
                        c => new CastMember
                        {
                            CastMemberId = c.Person.Id,
                            ShowId = tvShow.Id,
                            BirthDay = c.Person.Birthday,
                            Name = c.Person.Name
                        }).ToList();

                    tvShow.Cast = cast;
                    SaveToDb(tvShow);
                }
            }
        }

        private void SaveToDb(TvShow show)
        {
            _tvShowRepository.Save(show);
        }
    }
}