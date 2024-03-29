﻿using RAPC9Y_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace RAPC9Y_HFT_2022231.Logic
{
    public interface IRegionLogic
    {
        void Create(Regions item);
        void Delete(int id);
        Regions Read(int id);
        IEnumerable<Regions> ReadAll();
        void Update(Regions item);
    }
}