using RAPC9Y_HFT_2022231.Models;
using RAPC9Y_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPC9Y_HFT_2022231.Logic
{
    public class ChampionLogic : IChampionLogic
    {
        IRepository<Champions> repo;

        public ChampionLogic(IRepository<Champions> repo)
        {
            this.repo = repo;
        }

        public void Create(Champions item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Champions Read(int id)
        {
            var champ = this.repo.Read(id);
            if (champ == null)
            {
                throw new ArgumentException("There is no such champion!");
            }
            return champ;
        }

        public IQueryable<Champions> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Champions item)
        {
            this.repo.Update(item);
        }
    }
}
