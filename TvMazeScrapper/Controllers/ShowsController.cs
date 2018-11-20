using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TvMazeScrapper.Core.Models;
using TvMazeScrapper.Core.Repository;
using TvMazeScrapper.Util;

namespace TvMazeScrapper.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private ITvShowRepository _tvShowRepository;

        public ShowsController(ITvShowRepository tvShowRepository)
        {
            _tvShowRepository = tvShowRepository;
        }

        // GET: api/Shows/10/1
        [HttpGet("{itemsperPage}/{currentpage}", Name = "Get")]
        public Paginator Get(int itemsperPage,int currentpage)
        {
            int skip = currentpage * itemsperPage;
            var totalCount = _tvShowRepository.GetCount();
            var pageCunt = totalCount / itemsperPage;
            var tvshow=  _tvShowRepository.GetAllPaginated(skip, itemsperPage);
            return  new Paginator(){TvShow =tvshow ,CurentPage = currentpage,PageCount = pageCunt };
        }

     

    }
}
