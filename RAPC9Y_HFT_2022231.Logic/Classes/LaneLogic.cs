using RAPC9Y_HFT_2022231.Logic;
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
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Lanes Read(int id)
        {
            var lane = repo.Read(id);
            if (lane == null)
            {
                throw new ArgumentException("There is no such lane!");
            }
            return lane;
        }

        public IQueryable<Lanes> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Lanes item)
        {
            repo.Update(item);
        }
    }
}
