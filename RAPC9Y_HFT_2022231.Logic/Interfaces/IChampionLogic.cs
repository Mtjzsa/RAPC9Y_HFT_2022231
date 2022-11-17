using RAPC9Y_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;
using static RAPC9Y_HFT_2022231.Logic.ChampionLogic;

namespace RAPC9Y_HFT_2022231.Logic
{
    public interface IChampionLogic
    {
        void Create(Champions item);
        void Delete(int id);
        Champions Read(int id);
        IEnumerable<Champions> ReadAll();
        void Update(Champions item);
        IEnumerable<Champions> IonianChampionsWithoutManaAfter2010();
        IEnumerable<Champions> FemaleDemacianChamps();
        IEnumerable<Champions> SupportsWithOtherGender();
        IEnumerable<Champions> TopChampionsOrderByRelease();
        IEnumerable<ChampionInfo> ChampionsByRegion();
    }
}