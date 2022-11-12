using RAPC9Y_HFT_2022231.Models;
using System.Linq;

namespace RAPC9Y_HFT_2022231.Logic
{
    public interface IChampionLogic
    {
        void Create(Champions item);
        void Delete(int id);
        Champions Read(int id);
        IQueryable<Champions> ReadAll();
        void Update(Champions item);
    }
}