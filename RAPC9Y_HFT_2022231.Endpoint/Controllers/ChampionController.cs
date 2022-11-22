using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAPC9Y_HFT_2022231.Logic;
using RAPC9Y_HFT_2022231.Models;
using System.Collections;
using System.Collections.Generic;
using static RAPC9Y_HFT_2022231.Logic.ChampionLogic;

namespace RAPC9Y_HFT_2022231.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class ChampionController : ControllerBase
    {
        IChampionLogic logic;

        public ChampionController(IChampionLogic cl)
        {
            this.logic=cl;
        }

        [HttpGet]
        public IEnumerable<Champions> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Champions Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Champions c)
        {
            this.logic.Create(c);
        }

        [HttpPut]
        public void Update([FromBody] Champions c)
        {
            this.logic.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        

    }
}
