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
            
            Lanes Top = new Lanes()
            {
                Id = 1,
                LaneName = "Top",
            };
            Lanes Support = new Lanes()
            {
                Id = 5,
                LaneName = "Support",                
            };
            var lanes = new List<Lanes>()
            {
                Top,
                Support
            }.AsQueryable();
            
            Regions Demacia = new Regions()
            {
                Id = 3,
                RegionName = "Demacia",
            };
            Regions Ionia = new Regions()
            {
                Id = 4,
                RegionName = "Ionia"
            };
            var regions = new List<Regions>()
            {
                Demacia,
                Ionia
            }.AsQueryable();

            var champs = new List<Champions>()
            {
                new Champions()
                { 
                    Id=1,
                    Name="A",
                    Gender="Other",
                    Lane=Top,
                    LaneId=1,
                    Species="Human",
                    Resources="Energy",
                    Region=Ionia,
                    RegionId=4,
                    Release=2017
                },
                new Champions()
                { 
                    Id=2,
                    Name="B",
                    Gender="Male",
                    Lane=Top,
                    LaneId=1,
                    Species="Magically Altered",
                    Resources="Mana",
                    Region=Ionia,
                    RegionId=4,
                    Release=2019
                },
                new Champions()
                { 
                    Id=3,
                    Name="C",
                    Gender="Female",
                    Lane=Top,
                    LaneId=1,
                    Species="Yordle",
                    Resources="Manaless",
                    Region=Demacia,
                    RegionId=3,
                    Release=2013
                },
                new Champions()
                { 
                    Id=4,
                    Name="D",
                    Gender="Female",
                    Lane=Top,
                    LaneId=1,
                    Species="Vastayan",
                    Resources="Fury",
                    Region=Demacia,
                    RegionId=3,
                    Release=2010
                },
                new Champions()
                { 
                    Id=5,
                    Name="E",
                    Gender="Other",
                    Lane=Support,
                    LaneId=5,
                    Species="Chemically Altered",
                    Resources="Mana",
                    Region=Demacia,
                    RegionId=3,
                    Release=2016
                },
                new Champions()
                { 
                    Id=6,
                    Name="F",
                    Gender="Other",
                    Lane=Support,
                    LaneId=5,
                    Species="Yordle",
                    Resources="Rage",
                    Region=Demacia,
                    RegionId=3,
                    Release=2017
                },


            }.AsQueryable();
            mockChampRepo = new Mock<IRepository<Champions>>();
            mockChampRepo.Setup(m => m.ReadAll()).Returns(champs);
            ChampLogic = new ChampionLogic(mockChampRepo.Object);

            mockLaneRepo = new Mock<IRepository<Lanes>>();
            mockLaneRepo.Setup(m => m.ReadAll()).Returns(lanes);
            LaneLogic = new LaneLogic(mockLaneRepo.Object);

            mockRegionRepo = new Mock<IRepository<Regions>>();
            mockRegionRepo.Setup(t => t.ReadAll()).Returns(regions);
            RegionLogic = new RegionLogic(mockRegionRepo.Object);
        }

        [Test]
        public void IonianChampionsWithoutManaAfter2010()
        {
            var result = ChampLogic.IonianChampionsWithoutManaAfter2010();
            var expected = new List<Champions>()
            {

                new Champions()
                {
                    Id=1,
                    Name="A",
                    Gender ="Other",
                    Species="Human",
                    Resources="Energy",
                    LaneId=1,
                    RegionId=4,
                    Release=2017,
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
                    Id=3,
                    Name="C",
                    Gender ="Female",
                    Species="Yordle",
                    Resources="Manaless",
                    LaneId=1,
                    RegionId=3,
                    Release=2013,
                },
                new Champions()
                {
                    Id=4,
                    Name="D",
                    Gender ="Female",
                    Species="Vastayan",
                    Resources="Fury",
                    LaneId=1,
                    RegionId=3,
                    Release=2010,
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
                    Id=5,
                    Name="E",
                    Gender ="Other",
                    Species="Chemically Altered",
                    Resources="Mana",
                    LaneId=5,
                    RegionId=3,
                    Release=2016,
                },
                new Champions()
                {
                    Id=6,
                    Name="F",
                    Gender ="Other",
                    Species="Yordle",
                    Resources="Rage",
                    LaneId=5,
                    RegionId=3,
                    Release=2017,
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
                    Id=4,
                    Name="D",
                    Gender ="Female",
                    Species="Vastayan",
                    Resources="Fury",
                    LaneId=1,
                    RegionId=3,
                    Release=2010,
                },
                new Champions()
                {
                    Id=3,
                    Name="C",
                    Gender ="Female",
                    Species="Yordle",
                    Resources="Manaless",
                    LaneId=1,
                    RegionId=3,
                    Release=2013,
                },
                new Champions()
                {
                    Id=1,
                    Name="A",
                    Gender ="Other",
                    Species="Human",
                    Resources="Energy",
                    LaneId=1,
                    RegionId=4,
                    Release=2017,
                },
                new Champions()
                {
                    Id=2,
                    Name="B",
                    Gender ="Male",
                    Species="Magically Altered",
                    Resources="Mana",
                    LaneId=1,
                    RegionId=4,
                    Release=2019
                },
            };
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void ChampionsByRegionTest()
        {
            var result = ChampLogic.ChampionsByRegion().ToList();
            var expected = new List<Regions.RegionInfo>()
            {

                new Regions.RegionInfo()
                {
                    Region = "Demacia",
                    Year= 2014.00,
                    Number = 4
                },
                new Regions.RegionInfo()
                {
                    Region = "Ionia",
                    Year= 2018.00,
                    Number = 2
                },
            };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CreateChampCorrectlyTest()
        {
            var champ = new Champions() { Name = "Máté" };
            
            ChampLogic.Create(champ);

            mockChampRepo.Verify(t => t.Create(champ), Times.Once);
        }

        [Test]
        public void CreateChampIncorrectlyTest()
        {
            var champ = new Champions() { Name = "AB" };
            try
            {
                ChampLogic.Create(champ);
            }
            catch
            { 
            }
            mockChampRepo.Verify(t => t.Create(champ), Times.Never);
        }

        [Test]
        public void CreateChampWithNameNullTest()
        {
            var champ = new Champions();
            try
            {
                ChampLogic.Create(champ);
            }
            catch
            {
            }
            Assert.That(() => ChampLogic.Create(champ), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void DeleteTest()
        {
            ChampLogic.Delete(1);
            mockChampRepo.Verify(t=>t.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void ReadWithCorrectIdTest()
        {
            Champions expected = new Champions()
            {
                Id = 20,
                Name = "asfawq"
            };

            mockChampRepo.Setup(t => t.Read(20)).Returns(expected);

            var result = ChampLogic.Read(20);

            Assert.AreEqual(expected, result);
        }
    }
}
