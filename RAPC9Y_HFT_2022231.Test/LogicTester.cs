using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Moq;
using NUnit.Framework;
using RAPC9Y_HFT_2022231.Logic;
using RAPC9Y_HFT_2022231.Models;
using RAPC9Y_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.Internal.AsyncLock;
using System.Xml.Linq;
using static RAPC9Y_HFT_2022231.Logic.ChampionLogic;

namespace RAPC9Y_HFT_2022231.Test
{
    [TestFixture]
    public class LogicTester
    {
        ChampionLogic ChampLogic;
        RegionLogic RegionLogic;
        LaneLogic LaneLogic;
        Mock<IRepository<Champions>> mockChampRepo;
        Mock<IRepository<Lanes>> mockLaneRepo;
        Mock<IRepository<Regions>> mockRegionRepo;

        [SetUp]
        public void Init()
        {
            mockChampRepo = new Mock<IRepository<Champions>>();
            mockChampRepo.Setup(m => m.ReadAll()).Returns(new List<Champions>()
            {
                new Champions(){ Id=1,Name="A",Gender="",LaneId=1,Species="",Resources="Energy",RegionId=4,Release=2019},
                new Champions(){ Id=2,Name="B",Gender="",LaneId=1,Species="",Resources="Mana",RegionId=4,Release=2016},
                new Champions(){ Id=3,Name="C",Gender="",LaneId=1,Species="",Resources="Manaless",RegionId=4,Release=2013},
                new Champions(){ Id=4,Name="D",Gender="Female",LaneId=1,Species="",Resources="Fury",RegionId=4,Release=2010},
                new Champions(){ Id=5,Name="E",Gender="Other",LaneId=5,Species="",Resources="",RegionId=3,Release=2013},
                new Champions(){ Id=6,Name="F",Gender="Other",LaneId=5,Species="",Resources="",RegionId=3,Release=2017},


            }.AsQueryable());
            ChampLogic = new ChampionLogic(mockChampRepo.Object);

            mockLaneRepo = new Mock<IRepository<Lanes>>();
            mockLaneRepo.Setup(m => m.ReadAll()).Returns(new List<Lanes>()
            {
                new Lanes(){ Id=1, LaneName="A"},
                new Lanes(){ Id=2, LaneName="B"},
                new Lanes(){ Id=5, LaneName="C"},

            }.AsQueryable());
            LaneLogic = new LaneLogic(mockLaneRepo.Object);

            mockRegionRepo = new Mock<IRepository<Regions>>();
            mockRegionRepo.Setup(t => t.ReadAll()).Returns(new List<Regions>()
            {
                new Regions(){ Id=1, RegionName="Bandle-City"},
                new Regions(){ Id=4, RegionName="Ionia"},
                new Regions(){ Id=3, RegionName="Demacia"},
            }.AsQueryable());
            RegionLogic = new RegionLogic(mockRegionRepo.Object);
        }

        [Test]
        public void IonianEnergyChampionsAfter2010Test()
        {
            var result = ChampLogic.IonianEnergyChampionsAfter2010();
            var expected = new List<Champions>()
            {
                new Champions()
                {
                    Name="C",
                    Release=2019,
                    Species="Darkin",
                },
                new Champions()
                {
                    Name="A",
                    Release=2016,
                    Species="Human",
                },
                new Champions()
                {
                    Name="B",
                    Release=2018,
                    Species="Yordle",
                },
            };
            var exp = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Ionia", 2),
            };
            Assert.AreEqual(result, exp);
        }

        [Test]
        public void FemaleDemacianChampsTest()
        {
            var result = ChampLogic.FemaleDemacianChamps();
            var expected = new List<Champions>()
            {
                new Champions()
                {
                    Name = "D",
                },
                new Champions()
                {
                    Name = "E",
                },
            };
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void SupportsWithOtherGenderTest()
        {
            var result = ChampLogic.SupportsWithOtherGender();
            var expected = new List<Champions>()
            {
                new Champions()
                {
                    Name = "A",
                },
                new Champions()
                {
                    Name = "C",
                },
            };
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void TopChampionsOrderByReleaseTest()
        {
            var result = ChampLogic.TopChampionsOrderByRelease();
            var expected = new List<Champions>()
            {
                new Champions()
                {
                    Name="E",
                    Release=2010
                },
                new Champions()
                {
                    Name="D",
                    Release=2017
                },
            };
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void ChampionsByRegionTest()
        {
            var result = ChampLogic.ChampionsByRegion().ToList();
            var expected = new List<ChampionInfo>()
            {

                new ChampionInfo()
                {
                    Region = "Demacia",
                    Year=2014.5,
                    Number = 4
                },
                new ChampionInfo()
                {
                    Region = "Ionia",
                    Year=15.0,
                    Number = 2
                },
            };
            Assert.AreEqual(expected, result);
        }

    }
}
