using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAPC9Y_HFT_2022231.Logic;
using RAPC9Y_HFT_2022231.Models;
using System.Collections.Generic;

namespace RAPC9Y_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        IRegionLogic logic;

        public RegionController(IRegionLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Regions> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Regions Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Regions c)
        {
            this.logic.Create(c);
        }

        [HttpPut]
        public void Update([FromBody] Regions c)
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
