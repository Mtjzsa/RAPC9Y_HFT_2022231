using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAPC9Y_HFT_2022231.Logic;
using RAPC9Y_HFT_2022231.Models;
using System.Collections.Generic;

namespace RAPC9Y_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LaneController : ControllerBase
    {
        ILaneLogic logic;

        public LaneController(ILaneLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Lanes> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Lanes Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Lanes c)
        {
            this.logic.Create(c);
        }

        [HttpPut]
        public void Update([FromBody] Lanes c)
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
