using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using TvMazeScrapper.Scrapper;

namespace TvMazeScrapper.Jobs
{
    public class ScrapJob :IJob
    {
        private TvShowScrapper _tvMazeScrapper;

        public ScrapJob(TvShowScrapper tvMazeScrapper)
        {
            _tvMazeScrapper = tvMazeScrapper;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                _tvMazeScrapper.GetShowsFromRemoteApi();
            });
        }
    }
}
