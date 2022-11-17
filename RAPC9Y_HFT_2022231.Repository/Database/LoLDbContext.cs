using Microsoft.EntityFrameworkCore;
using RAPC9Y_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RAPC9Y_HFT_2022231.Repository
{
    public class LoLDbContext : DbContext
    {
        public virtual DbSet<Champions> Champions { get; set; }

        public virtual DbSet<Lanes> Lanes { get; set; }

        public virtual DbSet<Regions> Regions { get; set; }

        public LoLDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                        .UseLazyLoadingProxies()
                        .UseInMemoryDatabase("LolDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Champions>()
                .HasOne(t=>t.Region)
                .WithMany(t=>t.ChampionsByRegions)
                .HasForeignKey(t=>t.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Champions>()
                .HasOne(t => t.Lane)
                .WithMany(t => t.ChampionsByLanes)
                .HasForeignKey(t => t.LaneId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Champions>().HasData(new Champions[]
            {
                new Champions(){ Id=1,Name="Aatrox",Gender="Male",LaneId=1,Species="Darkin",Resources="Manaless",RegionId=8,Release=2013},
                new Champions(){ Id=2,Name="Ahri",Gender="Female",LaneId=3,Species="Vastayan",Resources="Mana",RegionId=4,Release=2011},
                new Champions(){ Id=3,Name="Akali",Gender="Female",LaneId=3,Species="Human",Resources="Energy",RegionId=4,Release=2010},
                new Champions(){ Id=4,Name="Akshan",Gender="Male",LaneId=1,Species="Human",Resources="Mana",RegionId=10,Release=2021},
                new Champions(){ Id=5,Name="Alistar",Gender="Male",LaneId=5,Species="Minotaur",Resources="Mana",RegionId=8,Release=2009},
                new Champions(){ Id=6,Name="Amumu",Gender="Male",LaneId=2,Species="Yordle",Resources="Mana",RegionId=10,Release=2009},
                new Champions(){ Id=7,Name="Anivia",Gender="Female",LaneId=3,Species="God",Resources="Mana",RegionId=12,Release=2009},
                new Champions(){ Id=8,Name="Annie",Gender="Female",LaneId=3,Species="Magically Altered",Resources="Mana",RegionId=8,Release=2009},
                new Champions(){ Id=9,Name="Aphelios",Gender="Male",LaneId=4,Species="Human",Resources="Mana",RegionId=11,Release=2019},
                new Champions(){ Id=10,Name="Ashe",Gender="Female",LaneId=4,Species="Human",Resources="Mana",RegionId=12,Release=2009},
                new Champions(){ Id=11,Name="Aurelion Sol",Gender="Male",LaneId=3,Species="Celestial",Resources="Mana",RegionId=11,Release=2016},
                new Champions(){ Id=12,Name="Azir",Gender="Male",LaneId=3,Species="God",Resources="Mana",RegionId=10,Release=2014},
                new Champions(){ Id=13,Name="Bard",Gender="Male",LaneId=5,Species="Celestial",Resources="Mana",RegionId=8,Release=2015},
                new Champions(){ Id=14,Name="Bel'Veth",Gender="Female",LaneId=2,Species="Void-Being",Resources="Manaless",RegionId=13,Release=2022},
                new Champions(){ Id=15,Name="Blitzcrank",Gender="Other",LaneId=5,Species="Golem",Resources="Mana",RegionId=14,Release=2009},
                new Champions(){ Id=16,Name="Brand",Gender="Male",LaneId=5,Species="Magically Altered",Resources="Mana",RegionId=8,Release=2011},
                new Champions(){ Id=17,Name="Braum",Gender="Male",LaneId=5,Species="Human",Resources="Mana",RegionId=12,Release=2014},
                new Champions(){ Id=18,Name="Caitlyn",Gender="Female",LaneId=4,Species="Human",Resources="Mana",RegionId=7,Release=2011},
                new Champions(){ Id=19,Name="Camille",Gender="Female",LaneId=1,Species="Human",Resources="Mana",RegionId=7,Release=2016},
                new Champions(){ Id=20,Name="Cassiopeia",Gender="Female",LaneId=3,Species="Magically Altered",Resources="Mana",RegionId=6,Release=2012},
                new Champions(){ Id=21,Name="Cho'Gath",Gender="Male",LaneId=1,Species="Void-Being",Resources="Mana",RegionId=13,Release=2009},
                new Champions(){ Id=22,Name="Corki",Gender="Male",LaneId=3,Species="Yordle",Resources="Mana",RegionId=1,Release=2009},
                new Champions(){ Id=23,Name="Darius",Gender="Male",LaneId=1,Species="Human",Resources="Mana",RegionId=6,Release=2012},
                new Champions(){ Id=24,Name="Diana",Gender="Female",LaneId=2,Species="Human",Resources="Mana",RegionId=11,Release=2012},
                new Champions(){ Id=25,Name="Dr.Mundo",Gender="Male",LaneId=1,Species="Chemically Altered",Resources="Health",RegionId=14,Release=2009},
                new Champions(){ Id=26,Name="Draven",Gender="Male",LaneId=4,Species="Human",Resources="Mana",RegionId=6,Release=2012},
                new Champions(){ Id=27,Name="Ekko",Gender="Male",LaneId=3,Species="Human",Resources="Mana",RegionId=14,Release=2015},
                new Champions(){ Id=28,Name="Elise",Gender="Female",LaneId=2,Species="Magically Altered",Resources="Mana",RegionId=9,Release=2012},
                new Champions(){ Id=29,Name="Evelynn",Gender="Female",LaneId=2,Species="Demon",Resources="Mana",RegionId=8,Release=2009},
                new Champions(){ Id=30,Name="Ezreal",Gender="Male",LaneId=4,Species="Human",Resources="Mana",RegionId=7,Release=2010},
                new Champions(){ Id=31,Name="Fiddlesticks",Gender="Other",LaneId=2,Species="Demon",Resources="Mana",RegionId=8,Release=2009},
                new Champions(){ Id=32,Name="Fiora",Gender="Female",LaneId=1,Species="Human",Resources="Mana",RegionId=3,Release=2012},
                new Champions(){ Id=33,Name="Fizz",Gender="Male",LaneId=3,Species="Yordle",Resources="Mana",RegionId=2,Release=2011},
                new Champions(){ Id=34,Name="Galio",Gender="Male",LaneId=3,Species="Golem",Resources="Mana",RegionId=3,Release=2010},
                new Champions(){ Id=35,Name="Gangplank",Gender="Male",LaneId=1,Species="Human",Resources="Mana",RegionId=2,Release=2009},
                new Champions(){ Id=36,Name="Garen",Gender="Male",LaneId=1,Species="Human",Resources="Manaless",RegionId=3,Release=2010},
                new Champions(){ Id=37,Name="Gnar",Gender="Male",LaneId=1,Species="Yordle",Resources="Rage",RegionId=12,Release=2014},
                new Champions(){ Id=38,Name="Gragas",Gender="Male",LaneId=1,Species="Human",Resources="Mana",RegionId=12,Release=2011},
                new Champions(){ Id=39,Name="Graves",Gender="Male",LaneId=2,Species="Human",Resources="Mana",RegionId=2,Release=2011},
                new Champions(){ Id=40,Name="Gwen",Gender="Female",LaneId=1,Species="Magically Altered",Resources="Mana",RegionId=9,Release=2021},
                new Champions(){ Id=41,Name="Hecarim",Gender="Male",LaneId=2,Species="Undead",Resources="Mana",RegionId=9,Release=2012},
                new Champions(){ Id=42,Name="Heimerdinger",Gender="Male",LaneId=3,Species="Yordle",Resources="Mana",RegionId=7,Release=2009},
                new Champions(){ Id=43,Name="Illaoi",Gender="Female",LaneId=1,Species="Human",Resources="Mana",RegionId=2,Release=2015},
                new Champions(){ Id=44,Name="Irelia",Gender="Female",LaneId=1,Species="Human",Resources="Mana",RegionId=4,Release=2010},
                new Champions(){ Id=45,Name="IV.Jarvan",Gender="Male",LaneId=2,Species="Human",Resources="Mana",RegionId=3,Release=2011},
                new Champions(){ Id=46,Name="Ivern",Gender="Male",LaneId=2,Species="Magically Altered",Resources="Mana",RegionId=4,Release=2016},
                new Champions(){ Id=47,Name="Janna",Gender="Female",LaneId=5,Species="God",Resources="Mana",RegionId=10,Release=2009},
                new Champions(){ Id=48,Name="Jax",Gender="Male",LaneId=1,Species="Unknown",Resources="Mana",RegionId=8,Release=2009},
                new Champions(){ Id=49,Name="Jayce",Gender="Male",LaneId=1,Species="Human",Resources="Mana",RegionId=7,Release=2012},
                new Champions(){ Id=50,Name="Jhin",Gender="Male",LaneId=4,Species="Human",Resources="Mana",RegionId=4,Release=2016},
                new Champions(){ Id=51,Name="Jinx",Gender="Female",LaneId=4,Species="Chemically Altered",Resources="Mana",RegionId=14,Release=2013},
                new Champions(){ Id=52,Name="Kai'Sa",Gender="Female",LaneId=4,Species="Void-Being",Resources="Mana",RegionId=13,Release=2018},
                new Champions(){ Id=53,Name="Kalista",Gender="Female",LaneId=4,Species="Undead",Resources="Mana",RegionId=9,Release=2014},
                new Champions(){ Id=54,Name="Karma",Gender="Female",LaneId=5,Species="Human",Resources="Mana",RegionId=4,Release=2011},
                new Champions(){ Id=55,Name="Karthus",Gender="Male",LaneId=2,Species="Undead",Resources="Mana",RegionId=9,Release=2009},
                new Champions(){ Id=56,Name="Kassadin",Gender="Male",LaneId=3,Species="Void-Being",Resources="Mana",RegionId=13,Release=2009},
                new Champions(){ Id=57,Name="Katarina",Gender="Female",LaneId=3,Species="Human",Resources="Manaless",RegionId=6,Release=2009},
                new Champions(){ Id=58,Name="Kayle",Gender="Female",LaneId=1,Species="Magically Altered",Resources="Mana",RegionId=3,Release=2009},
                new Champions(){ Id=59,Name="Kayn",Gender="Male",LaneId=2,Species="Darkin",Resources="Mana",RegionId=8,Release=2017},
                new Champions(){ Id=60,Name="Kennen",Gender="Male",LaneId=1,Species="Yordle",Resources="Energy",RegionId=4,Release=2010},
                new Champions(){ Id=61,Name="Kha'Zix",Gender="Male",LaneId=2,Species="Void-Being",Resources="Mana",RegionId=13,Release=2012},
                new Champions(){ Id=62,Name="Kindred",Gender="Other",LaneId=2,Species="God",Resources="Mana",RegionId=8,Release=2015},
                new Champions(){ Id=63,Name="Kled",Gender="Male",LaneId=1,Species="Yordle",Resources="Courage",RegionId=6,Release=2016},
                new Champions(){ Id=64,Name="Kog'Maw",Gender="Male",LaneId=4,Species="Void-Being",Resources="Mana",RegionId=13,Release=2010},
                new Champions(){ Id=65,Name="LeBlanc",Gender="Femlae",LaneId=3,Species="Magically Altered",Resources="Mana",RegionId=6,Release=2010},
                new Champions(){ Id=66,Name="Lee Sin",Gender="Male",LaneId=2,Species="Human",Resources="Energy",RegionId=4,Release=2011},
                new Champions(){ Id=67,Name="Leona",Gender="Female",LaneId=5,Species="Human",Resources="Mana",RegionId=11,Release=2011},
                new Champions(){ Id=68,Name="Lillia",Gender="Female",LaneId=2,Species="Spirit",Resources="Mana",RegionId=4,Release=2020},
                new Champions(){ Id=69,Name="Lissandra",Gender="Female",LaneId=3,Species="Human",Resources="Mana",RegionId=12,Release=2013},
                new Champions(){ Id=70,Name="Lucian",Gender="Male",LaneId=4,Species="Human",Resources="Mana",RegionId=3,Release=2013},
                new Champions(){ Id=71,Name="Lulu",Gender="Female",LaneId=5,Species="Yordle",Resources="Mana",RegionId=1,Release=2012},
                new Champions(){ Id=72,Name="Lux",Gender="Female",LaneId=5,Species="Human",Resources="Mana",RegionId=3,Release=2010},
                new Champions(){ Id=73,Name="Malphite",Gender="Male",LaneId=1,Species="Golem",Resources="Mana",RegionId=10,Release=2009},
                new Champions(){ Id=74,Name="Malzahar",Gender="Male",LaneId=3,Species="Void-Being",Resources="Mana",RegionId=13,Release=2010},
                new Champions(){ Id=75,Name="Maokai",Gender="Male",LaneId=1,Species="Spirit",Resources="Mana",RegionId=9,Release=2009},
                new Champions(){ Id=76,Name="Master Yi",Gender="Male",LaneId=2,Species="Human",Resources="Mana",RegionId=4,Release=2010},
                new Champions(){ Id=77,Name="Miss Fortune",Gender="Female",LaneId=4,Species="Human",Resources="Mana",RegionId=2,Release=2010},
                new Champions(){ Id=78,Name="Mordekaiser",Gender="Male",LaneId=1,Species="Revenant",Resources="Shield",RegionId=6,Release=2010},
                new Champions(){ Id=79,Name="Morgana",Gender="Female",LaneId=5,Species="Magically Altered",Resources="Mana",RegionId=3,Release=2009},
                new Champions(){ Id=80,Name="Nami",Gender="Female",LaneId=5,Species="Vastayan",Resources="Mana",RegionId=8,Release=2012},
                new Champions(){ Id=81,Name="Nasus",Gender="Male",LaneId=1,Species="God",Resources="Mana",RegionId=10,Release=2009},
                new Champions(){ Id=82,Name="Nautilus",Gender="Male",LaneId=5,Species="Revenant",Resources="Mana",RegionId=2,Release=2012},
                new Champions(){ Id=83,Name="Neeki",Gender="Female",LaneId=3,Species="Vastayan",Resources="Mana",RegionId=5,Release=2018},
                new Champions(){ Id=84,Name="Nidalee",Gender="Female",LaneId=2,Species="Vastayan",Resources="Mana",RegionId=8,Release=2009},
                new Champions(){ Id=85,Name="Nilah",Gender="Female",LaneId=4,Species="Magically Altered",Resources="Mana",RegionId=2,Release=2022},
                new Champions(){ Id=86,Name="Nocturne",Gender="Male",LaneId=20,Species="Demon",Resources="Mana",RegionId=8,Release=2011},
                new Champions(){ Id=87,Name="Nunu & Willump",Gender="Male",LaneId=2,Species="Human",Resources="Mana",RegionId=12,Release=2009},
                new Champions(){ Id=88,Name="Olaf",Gender="Male",LaneId=2,Species="Human",Resources="Mana",RegionId=12,Release=2010},
                new Champions(){ Id=89,Name="Orianna",Gender="Female",LaneId=3,Species="Golem",Resources="Mana",RegionId=7,Release=2011},
                new Champions(){ Id=90,Name="Ornn",Gender="Male",LaneId=1,Species="God",Resources="Mana",RegionId=12,Release=2017},
                new Champions(){ Id=91,Name="Pantheon",Gender="Male",LaneId=1,Species="Human",Resources="Mana",RegionId=11,Release=2010},
                new Champions(){ Id=92,Name="Poppy",Gender="Male",LaneId=1,Species="Yordle",Resources="Mana",RegionId=3,Release=2010},
                new Champions(){ Id=93,Name="Pyke",Gender="Male",LaneId=5,Species="Revenant",Resources="Mana",RegionId=2,Release=2018},
                new Champions(){ Id=94,Name="Qiyana",Gender="Female",LaneId=3,Species="Human",Resources="Mana",RegionId=5,Release=2019},
                new Champions(){ Id=95,Name="Quinn",Gender="Female",LaneId=1,Species="Human",Resources="Mana",RegionId=3,Release=2013},
                new Champions(){ Id=96,Name="Rakan",Gender="Male",LaneId=5,Species="Vastayan",Resources="Mana",RegionId=4,Release=2017},
                new Champions(){ Id=97,Name="Rammus",Gender="Male",LaneId=2,Species="God",Resources="Mana",RegionId=10,Release=2009},
                new Champions(){ Id=98,Name="Rek'Sai",Gender="Female",LaneId=2,Species="Void-Being",Resources="Rage",RegionId=13,Release=2014},
                new Champions(){ Id=99,Name="Rell",Gender="Female",LaneId=5,Species="Magivally Altered",Resources="Mana",RegionId=6,Release=2013},
                new Champions(){ Id=100,Name="Renata Glasc",Gender="Female",LaneId=5,Species="Chemically Altered",Resources="Mana",RegionId=14,Release=2022},
                new Champions(){ Id=101,Name="Renekton",Gender="Male",LaneId=1,Species="God",Resources="Fury",RegionId=10,Release=2011},
                new Champions(){ Id=102,Name="Rengar",Gender="Male",LaneId=2,Species="Vastayan",Resources="Ferocity",RegionId=5,Release=2012},
                new Champions(){ Id=103,Name="Riven",Gender="Female",LaneId=1,Species="Human",Resources="Manaless",RegionId=4,Release=2011},
                new Champions(){ Id=104,Name="Rumble",Gender="Male",LaneId=1,Species="Yordle",Resources="Heat",RegionId=1,Release=2011},
                new Champions(){ Id=105,Name="Ryze",Gender="Male",LaneId=3,Species="Magically Altered",Resources="Mana",RegionId=8,Release=2009},
                new Champions(){ Id=106,Name="Samira",Gender="Female",LaneId=4,Species="Human",Resources="Mana",RegionId=6,Release=2020},
                new Champions(){ Id=107,Name="Sejuani",Gender="Female",LaneId=2,Species="Human",Resources="Mana",RegionId=12,Release=2012},
                new Champions(){ Id=108,Name="Senna",Gender="Female",LaneId=5,Species="Human",Resources="Mana",RegionId=3,Release=2019},
                new Champions(){ Id=109,Name="Seraphine",Gender="Female",LaneId=5,Species="Human",Resources="Mana",RegionId=7,Release=2020},
                new Champions(){ Id=110,Name="Sett",Gender="Male",LaneId=1,Species="Vastayan",Resources="Grit",RegionId=4,Release=2020},
                new Champions(){ Id=111,Name="Shaco",Gender="Male",LaneId=2,Species="Spirit",Resources="Mana",RegionId=8,Release=2009},
                new Champions(){ Id=112,Name="Shen",Gender="Male",LaneId=1,Species="Human",Resources="Energy",RegionId=4,Release=2010},
                new Champions(){ Id=113,Name="Shyvana",Gender="Female",LaneId=2,Species="Magically Altered",Resources="Fury",RegionId=3,Release=2011},
                new Champions(){ Id=114,Name="Singed",Gender="Male",LaneId=1,Species="Chemically Altered",Resources="Mana",RegionId=14,Release=2009},
                new Champions(){ Id=115,Name="Sion",Gender="Male",LaneId=1,Species="Revenant",Resources="Mana",RegionId=6,Release=2009},
                new Champions(){ Id=116,Name="Sivir",Gender="Female",LaneId=4,Species="Human",Resources="Mana",RegionId=10,Release=2009},
                new Champions(){ Id=117,Name="Skarner",Gender="Male",LaneId=2,Species="Brackern",Resources="Mana",RegionId=10,Release=2011},
                new Champions(){ Id=118,Name="Sona",Gender="Female",LaneId=5,Species="Human",Resources="Mana",RegionId=8,Release=2013},
                new Champions(){ Id=119,Name="Soraka",Gender="Female",LaneId=5,Species="Celestial",Resources="Mana",RegionId=11,Release=2009},
                new Champions(){ Id=120,Name="Swain",Gender="Male",LaneId=3,Species="Magically Altered",Resources="Mana",RegionId=6,Release=2010},
                new Champions(){ Id=121,Name="Sylas",Gender="Male",LaneId=3,Species="Human",Resources="Mana",RegionId=3,Release=2019},
                new Champions(){ Id=122,Name="Syndra",Gender="Female",LaneId=3,Species="Human",Resources="Mana",RegionId=4,Release=2012},
                new Champions(){ Id=123,Name="Tahm Kech",Gender="Male",LaneId=1,Species="Demon",Resources="Mana",RegionId=2,Release=2015},
                new Champions(){ Id=124,Name="Taliyah",Gender="Female",LaneId=2,Species="Human",Resources="Mana",RegionId=10,Release=2016},
                new Champions(){ Id=125,Name="Talon",Gender="Male",LaneId=3,Species="Human",Resources="Mana",RegionId=6,Release=2011},
                new Champions(){ Id=126,Name="Taric",Gender="Male",LaneId=5,Species="Human",Resources="Mana",RegionId=11,Release=2009},
                new Champions(){ Id=127,Name="Teemo",Gender="Male",LaneId=1,Species="Yordle",Resources="Mana",RegionId=1,Release=2009},
                new Champions(){ Id=128,Name="Thresh",Gender="Male",LaneId=5,Species="Undead",Resources="Mana",RegionId=9,Release=2013},
                new Champions(){ Id=129,Name="Tristana",Gender="Female",LaneId=4,Species="Yordle",Resources="Mana",RegionId=1,Release=2009},
                new Champions(){ Id=130,Name="Trundle",Gender="Male",LaneId=2,Species="Troll",Resources="Mana",RegionId=12,Release=2010},
                new Champions(){ Id=131,Name="Tryndamere",Gender="Male",LaneId=1,Species="Magically Altered",Resources="Fury",RegionId=12,Release=2009},
                new Champions(){ Id=132,Name="Twisted Fate",Gender="Male",LaneId=3,Species="Human",Resources="Mana",RegionId=2,Release=2009},
                new Champions(){ Id=133,Name="Twitch",Gender="Male",LaneId=4,Species="Chemically Altered",Resources="Mana",RegionId=14,Release=2009},
                new Champions(){ Id=134,Name="Udyr",Gender="Male",LaneId=1,Species="Vastayan",Resources="Mana",RegionId=12,Release=2009},
                new Champions(){ Id=135,Name="Urgot",Gender="Male",LaneId=1,Species="Chemically Altered",Resources="Mana",RegionId=6,Release=2010},
                new Champions(){ Id=136,Name="Varus",Gender="Male",LaneId=4,Species="Darkin",Resources="Mana",RegionId=8,Release=2012},
                new Champions(){ Id=137,Name="Vayne",Gender="Female",LaneId=4,Species="Human",Resources="Mana",RegionId=3,Release=2011},
                new Champions(){ Id=138,Name="Veigar",Gender="Male",LaneId=3,Species="Yordle",Resources="Mana",RegionId=1,Release=2009},
                new Champions(){ Id=139,Name="Vel'Koz",Gender="Male",LaneId=3,Species="Void-Being",Resources="Mana",RegionId=13,Release=2014},
                new Champions(){ Id=140,Name="Vex",Gender="Female",LaneId=3,Species="Yordle",Resources="Mana",RegionId=9,Release=2021},
                new Champions(){ Id=141,Name="Vi",Gender="Female",LaneId=2,Species="Human",Resources="Mana",RegionId=14,Release=2012},
                new Champions(){ Id=142,Name="Viego",Gender="Male",LaneId=2,Species="Undead",Resources="Manaless",RegionId=9,Release=2021},
                new Champions(){ Id=143,Name="Viktor",Gender="Male",LaneId=3,Species="Human",Resources="Mana",RegionId=14,Release=2011},
                new Champions(){ Id=144,Name="Vladimir",Gender="Male",LaneId=3,Species="Magically Altered",Resources="Bloodthirst",RegionId=6,Release=2010},
                new Champions(){ Id=145,Name="Volibear",Gender="Male",LaneId=1,Species="God",Resources="Mana",RegionId=12,Release=2011},
                new Champions(){ Id=146,Name="Warwick",Gender="Male",LaneId=2,Species="Chemically Altered",Resources="Mana",RegionId=14,Release=2009},
                new Champions(){ Id=147,Name="Wukong",Gender="Male",LaneId=1,Species="Vastayan",Resources="Mana",RegionId=4,Release=2011},
                new Champions(){ Id=148,Name="Xayah",Gender="Female",LaneId=4,Species="Vastayan",Resources="Mana",RegionId=4,Release=2017},
                new Champions(){ Id=149,Name="Xerath",Gender="Male",LaneId=3,Species="God",Resources="Mana",RegionId=10,Release=2011},
                new Champions(){ Id=150,Name="Xin Zhao",Gender="Male",LaneId=2,Species="Human",Resources="Mana",RegionId=3,Release=2010},
                new Champions(){ Id=151,Name="Yasuo",Gender="Male",LaneId=3,Species="Human",Resources="Flow",RegionId=4,Release=2013},
                new Champions(){ Id=152,Name="Yone",Gender="Male",LaneId=1,Species="Magically Altered",Resources="Manaless",RegionId=4,Release=2020},
                new Champions(){ Id=153,Name="Yorick",Gender="Male",LaneId=1,Species="Magically Altered",Resources="Mana",RegionId=9,Release=2011},
                new Champions(){ Id=154,Name="Yuumi",Gender="Female",LaneId=5,Species="Magically Altered",Resources="Mana",RegionId=1,Release=2019},
                new Champions(){ Id=155,Name="Zac",Gender="Male",LaneId=2,Species="Golem",Resources="Health",RegionId=14,Release=2013},
                new Champions(){ Id=156,Name="Zed",Gender="Male",LaneId=3,Species="Human",Resources="Energy",RegionId=4,Release=2012},
                new Champions(){ Id=157,Name="Zeri",Gender="Female",LaneId=4,Species="Human",Resources="Mana",RegionId=14,Release=2022},
                new Champions(){ Id=158,Name="Ziggs",Gender="Male",LaneId=3,Species="Yordle",Resources="Mana",RegionId=7,Release=2012},
                new Champions(){ Id=159,Name="Zilean",Gender="Male",LaneId=5,Species="Human",Resources="Mana",RegionId=8,Release=2009},
                new Champions(){ Id=160,Name="Zoe",Gender="Female",LaneId=3,Species="Human",Resources="Mana",RegionId=11,Release=2017},
                new Champions(){ Id=161,Name="Zyra",Gender="Other",LaneId=5,Species="Unknown",Resources="Mana",RegionId=5,Release=2012},
            });

            modelBuilder.Entity<Lanes>().HasData(new Lanes[]
            {
                new Lanes() { Id=1, LaneName="Top"},
                new Lanes(){ Id=2, LaneName="Jungle"},
                new Lanes(){ Id=3, LaneName="Middle"},
                new Lanes(){ Id=4, LaneName="Bot"},
                new Lanes(){ Id=5, LaneName="Support"},
            });

            modelBuilder.Entity<Regions>().HasData(new Regions[]
            {
                new Regions() { Id=1, RegionName="Bandle-City"}, 
                new Regions() { Id=2, RegionName="Bilgewater"},
                new Regions() { Id=3, RegionName="Demacia"},
                new Regions() { Id=4, RegionName="Ionia"},
                new Regions() { Id=5, RegionName="Ixtal"},
                new Regions() { Id=6, RegionName="Noxus"},
                new Regions() { Id=7, RegionName="Piltover"},
                new Regions() { Id=8, RegionName="Runeterra"},
                new Regions() { Id=9, RegionName="Shadow Isles"},
                new Regions() { Id=10, RegionName="Shurima"},
                new Regions() { Id=11, RegionName="Targon"},
                new Regions() { Id=12, RegionName="Freljord"},
                new Regions() { Id=13, RegionName="Void"},
                new Regions() { Id=14, RegionName="Zaun"},
            });

        }

    }
}
