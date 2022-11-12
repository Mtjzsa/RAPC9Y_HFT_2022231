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
                new Champions("1#A#Other#5#Human#Manaless#1#2016"),
                new Champions("2#B#Female#5#Yordle#Manaless#2#2018"),
                new Champions("3#C#Other#5#Darkin#Manaless#2#2019"),
                new Champions("4#D#Female#1#Human#Mana#3#2017"),
                new Champions("5#E#Female#1#Human#Manaless#3#2010"),


            }.AsQueryable());
            ChampLogic = new ChampionLogic(mockChampRepo.Object);

            mockLaneRepo = new Mock<IRepository<Lanes>>();
            mockLaneRepo.Setup(m => m.ReadAll()).Returns(new List<Lanes>()
            {
                new Lanes("1#A"),
                new Lanes("5#B"),
                new Lanes("3#C"),

            }.AsQueryable());
            LaneLogic = new LaneLogic(mockLaneRepo.Object);

            mockRegionRepo = new Mock<IRepository<Regions>>();
            mockRegionRepo.Setup(t => t.ReadAll()).Returns(new List<Regions>()
            {
                new Regions("1#A"),
                new Regions("2#B"),
                new Regions("3#C"),
            }.AsQueryable());
            RegionLogic = new RegionLogic(mockRegionRepo.Object);
        }

        [Test]
        public void ManalessChampionsAfter2010Test()
        {
            var result = ChampLogic.ManalessChampionsAfter2010().ToList();
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

    }
}
