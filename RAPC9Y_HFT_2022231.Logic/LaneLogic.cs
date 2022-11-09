using RAPC9Y_HFT_2022231.Models;
using RAPC9Y_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPC9Y_HFT_2022231.Logic
{
    public class LaneLogic : ILaneLogic
    {
        IRepository<Lanes> repo;

        public LaneLogic(IRepository<Lanes> repo)
        {
            this.repo = repo;
        }

        public void Create(Lanes item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Lanes Read(int id)
        {
            var lane = this.repo.Read(id);
            if (lane == null)
            {
                throw new ArgumentException("There is no such lane!");
            }
            return lane;
        }

        public IQueryable<Lanes> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Lanes item)
        {
            this.repo.Update(item);
        }

        public void ChampionsByLanes()
        {
                
        }
    }
}
