using RAPC9Y_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPC9Y_HFT_2022231.Repository
{
    public class RegionRepository : Repository<Regions>, IRepository<Regions>
    {
        public RegionRepository(LoLDbContext ctx) : base(ctx)
        {
        }

        public override Regions Read(int id)
        {
            return ctx.Regions.FirstOrDefault(item => item.Id == id);
        }

        public override void Update(Regions item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }

}
