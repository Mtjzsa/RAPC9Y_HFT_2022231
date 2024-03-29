﻿using RAPC9Y_HFT_2022231.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RAPC9Y_HFT_2022231.Logic
{
    public interface ILaneLogic
    {
        void Create(Lanes item);
        void Delete(int id);
        Lanes Read(int id);
        IEnumerable<Lanes> ReadAll();
        void Update(Lanes item);
    }
}