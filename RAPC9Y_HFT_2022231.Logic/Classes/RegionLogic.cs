using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
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
    public class RegionLogic : IRegionLogic
    {
        IRepository<Regions> repo;

        public RegionLogic(IRepository<Regions> repo)
        {
            this.repo = repo;
        }

        public void Create(Regions item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Regions Read(int id)
        {
            var r = this.repo.Read(id);
            if (r == null)
            {
                throw new ArgumentException("There is no such region!");
            }
            return r;
        }

        public IEnumerable<Regions> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Regions item)
        {
            this.repo.Update(item);
        }
    }
}
