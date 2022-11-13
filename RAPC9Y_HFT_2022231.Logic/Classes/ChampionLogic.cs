using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using RAPC9Y_HFT_2022231.Logic;
using RAPC9Y_HFT_2022231.Models;
using RAPC9Y_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Champions Read(int id)
        {
            var champ = repo.Read(id);
            if (champ == null)
            {
                throw new ArgumentException("There is no such champion!");
            }
            return champ;
        }

        public IEnumerable<Champions> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Champions item)
        {
            repo.Update(item);
        }

        public IEnumerable<Champions> IonianEnergyChampionsAfter2010()
        {
            return from x in this.repo.ReadAll()
                   where x.Release > 2010 && !x.Resources.Equals("Mana") && x.Region.RegionName.Equals("Ionia")
                   orderby x.Species
                   select new Champions()
                   {
                       Name = x.Name,
                       Release = x.Release,
                       Species = x.Species,
                   };
        }

        public IEnumerable<Champions> FemaleDemacianChamps()
        {
            return from x in this.repo.ReadAll()
                   where x.Gender == "Female" && x.Region.RegionName.Equals("Demacia")
                   select new Champions()
                   {
                       Name = x.Name
                   };
        }

        public IEnumerable<Champions> SupportsWithOtherGender()
        {
            return from x in this.repo.ReadAll()
                   where x.Gender == "Other" && x.Lane.LaneName == "Support"
                   select new Champions()
                   {
                       Name = x.Name,
                   };
        }

        public IEnumerable<Champions> TopChampionsOrderByRelease()
        {
            return from x in this.repo.ReadAll()
                   where x.Lane.LaneName.Equals("Top")
                   orderby x.Release
                   select new Champions()
                   {
                       Name = x.Name,
                       Release = x.Release,
                   };
        }

        public IEnumerable<ChampionInfo> ChampionsByRegion()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Region.RegionName into g
                   select new ChampionInfo()
                   {
                       Region = g.Key.ToString(),
                       Year = g.Average(t=>t.Release),
                       Number = g.Count()
                   };
        }

        public class ChampionInfo
        {
            public string Region { get; set; }
            public double Year { get; set; }

            public int Number { get; set; }

            public override bool Equals(object obj)
            {
                ChampionInfo b = obj as ChampionInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Region == b.Region
                        && this.Year ==b.Year
                        && this.Number == b.Number;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Region, this.Year, this.Number);
            }
        }
    }
}
