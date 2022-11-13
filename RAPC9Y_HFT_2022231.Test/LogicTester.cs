using Moq;
using NUnit.Framework;
using RAPC9Y_HFT_2022231.Logic;
using RAPC9Y_HFT_2022231.Models;
using RAPC9Y_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                new Champions(){ Id=1,Name="A",Gender="",LaneId=1,Species="",Resources="",RegionId=8,Release=2013},
                new Champions(){ Id=2,Name="B",Gender="",LaneId=1,Species="",Resources="",RegionId=8,Release=2013},
                new Champions(){ Id=3,Name="C",Gender="",LaneId=1,Species="",Resources="",RegionId=8,Release=2013},
                new Champions(){ Id=4,Name="D",Gender="",LaneId=1,Species="",Resources="",RegionId=8,Release=2013},
                new Champions(){ Id=5,Name="E",Gender="",LaneId=1,Species="",Resources="",RegionId=8,Release=2013},


            }.AsQueryable());
            ChampLogic = new ChampionLogic(mockChampRepo.Object);

            mockLaneRepo = new Mock<IRepository<Lanes>>();
            mockLaneRepo.Setup(m => m.ReadAll()).Returns(new List<Lanes>()
            {
                new Lanes(){ Id=1, LaneName="A"},
                new Lanes(){ Id=2, LaneName="B"},
                new Lanes(){ Id=3, LaneName="C"},

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
            var result = ChampLogic.IonianEnergyChampionsAfter2010().ToList();
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
            Assert.AreEqual(result, expected);
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
        public void ChampionsByRegionAfter2016Test()
        {
            var result = ChampLogic.ChampionsByRegionAfter2016().ToList();
            var expected = new List<ChampionInfo>()
            {

                new ChampionInfo()
                {
                    Region = 2,
                    Number = 2
                },
                new ChampionInfo()
                {
                    Region = 3,
                    Number = 1
                },
            };
            Assert.AreEqual(expected, result);
        }

    }
}
