using RAPC9Y_HFT_2022231.Models;
using System.Linq;

namespace RAPC9Y_HFT_2022231.Logic
{
    public interface IRegionLogic
    {
        void Create(Regions item);
        void Delete(int id);
        Regions Read(int id);
        IQueryable<Regions> ReadAll();
        void Update(Regions item);
    }
}