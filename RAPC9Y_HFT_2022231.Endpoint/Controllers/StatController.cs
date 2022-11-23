using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAPC9Y_HFT_2022231.Models;
using static RAPC9Y_HFT_2022231.Logic.ChampionLogic;
using System.Collections.Generic;
using RAPC9Y_HFT_2022231.Logic;

namespace RAPC9Y_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {

        IChampionLogic logic;

        public StatController(IChampionLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Champions> IonianChampionsWithoutManaAfter2010()
        {
            return this.logic.IonianChampionsWithoutManaAfter2010();
        }

        [HttpGet]
        public IEnumerable<Champions> FemaleDemacianChampions()
        {
            return this.logic.FemaleDemacianChamps();
        }

        [HttpGet]
        public IEnumerable<Champions> SupportWithOtherGender()
        {
            return this.logic.SupportsWithOtherGender();
        }

        [HttpGet]
        public IEnumerable<Champions> TopChampionsOrderByRelease()
        {
            return this.logic.TopChampionsOrderByRelease();
        }

        [HttpGet]
        public IEnumerable<Regions.RegionInfo> RegionInfo()
        {
            return this.logic.ChampionsByRegion();
        }

    }
}
