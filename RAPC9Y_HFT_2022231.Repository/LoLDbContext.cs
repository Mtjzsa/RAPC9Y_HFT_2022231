using Microsoft.EntityFrameworkCore;
using RAPC9Y_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public LoLDbContext(DbContextOptions<LoLDbContext> options):base(options)
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
            modelBuilder.Entity<Champions>(champs => champs
            .HasOne(champs => champs.Lane)
            .WithMany(lane => lane.ChampionsByLanes)
            .HasForeignKey(champs => champs.LaneId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Champions>(champs => champs
            .HasOne(champs => champs.Region)
            .WithMany(regions => regions.ChampionsByRegions)
            .HasForeignKey(champs => champs.RegionId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Champions>().HasData(new Champions[]
            {
                new Champions("1#Aatrox#Male#1#Darkin#Manaless#8#2013"),
                new Champions("2#Ahri#Female#3#Vastayan#Mana#4#2011"),
                new Champions("3#Akali#Female#3#Human#Energy#4#2010"),
                new Champions("4#Akshan#Male#1#Human#Mana#10#2021"),
                new Champions("5#Alistar#Male#5#Minotaur#Mana#8#2009"),
                new Champions("6#Amumu#Male#2#Yordle#Manal#10#2009"),
                new Champions("7#Anivia#Female#3#God#Manal#12#2009"),
                new Champions("8#Annie#Female#3#Magically Altered#Mana#8#2009"),
                new Champions("9#Aphelios#Male#4#Human#Mana#11#2019"),
                new Champions("10#Ashe#Female#4#Human#Mana#12#2009"),
                new Champions("11#Aurelion Sol#Male#3#Celestial#Mana#11#2016"),
                new Champions("12#Azir#Male#3#God#Mana#10#2014"),
                new Champions("13#Bard#Male#5#Celestial#Mana#8#2015"),
                new Champions("14#Bel'Veth#Female#2#Void-Being#Manaless#13#2022"),
                new Champions("15#Blitzcrank#Other#5#Golem#Mana#14#2009"),
                new Champions("16#Brand#Male#5#Magically Altered#Mana#8#2011"),
                new Champions("17#Braum#Male#5#Human#Mana#12#2014"),
                new Champions("18#Caitlyn#Female#4#Human#Mana#7#2011"),
                new Champions("19#Camille#Female#1#Human#Mana#7#2016"),
                new Champions("20#Cassiopeia#Female#3#Magically Altered#Mana#6#2012"),
                new Champions("21#Cho'Gath#Male#1#Void-Being#Mana#13#2009"),
                new Champions("22#Corki#Male#3#Yordle#Mana#1#2009"),
                new Champions("23#Darius#Male#1#Human#Mana#6#2012"),
                new Champions("24#Diana#Female#2#Human#Mana#11#2012"),
                new Champions("25#Dr. Mundo#Male#1#Chemically Altered#Health#14#2009"),
                new Champions("26#Draven#Male#4#Human#Mana#6#2012"),
                new Champions("27#Ekko#Male#3#Human#Mana#14#2015"),
                new Champions("28#Elise#Female#2#Magically Altered#Mana#9#2012"),
                new Champions("29#Evelynn#Female#2#Demon#Mana#8#2009"),
                new Champions("30#Ezreal#Male#4#Human#Mana#7#2010"),
                new Champions("31#Fiddlesticks#Other#2#Demon#Mana#8#2009"),
                new Champions("32#Fiora#Female#1#Human#Mana#3#2012"),
                new Champions("33#Fizz#Male#3#Yordle#Mana#2#2011"),
                new Champions("34#Galio#Male#3#Golem#Mana#3#2010"),
                new Champions("35#Gangplank#Male#1#Human#Mana#2#2009"),
                new Champions("36#Garen#Male#1#Human#Manaless#3#2010"),
                new Champions("37#Gnar#Male#1#Yordle#Rage#12#2014"),
                new Champions("38#Gragas#Male#1#Human#Mana#12#2011"),
                new Champions("39#Graves#Male#2#Human#Mana#2#2011"),
                new Champions("40#Gwen#Female#1#Magically Altered#Mana#9#2021"),
                new Champions("41#Hecarim#Male#2#Undead#Mana#9#2012"),
                new Champions("42#Heimerdinger#Male#3#Yordle#Mana#7#2009"),
                new Champions("43#Illaoi#Female#1#Human#Mana#2#2015"),
                new Champions("44#Irelia#Female#1#Human#Mana#4#2010"),
                new Champions("45#IV. Jarvan#Male#2#Human#Mana#3#2011"),
                new Champions("46#Ivern#Male#2#Magically Altered#Mana#4#2016"),
                new Champions("47#Janna#Female#5#God#Mana#10#2009"),
                new Champions("48#Jax#Male#1#Unknown#Mana#8#2009"),
                new Champions("49#Jayce#Male#1#Human#Mana#7#2012"),
                new Champions("50#Jhin#Male#4#Human#Mana#4#2016"),
                new Champions("51#Jinx#Female#4#Chemically Altered#Mana#14#2013"),
                new Champions("52#Kai'Sa#Female#4#Void-Being#Mana#13#2018"),
                new Champions("53#Kalista#Female#4#Undead#Mana#9#2014"),
                new Champions("54#Karma#Female#5#Human#Mana#4#2011"),
                new Champions("55#Karthus#Male#2#Undead#Mana#9#2009"),
                new Champions("56#Kassadin#Male#3#Void-Being#Mana#13#2009"),
                new Champions("57#Katarina#Female#3#Human#Manaless#6#2009"),
                new Champions("58#Kayle#Female#1#Magically Altered#Mana#3#2009"),
                new Champions("59#Kayn#Male#2#Darkin#Mana#8#2017"),
                new Champions("60#Kennen#Male#1#Yordle#Energy#4#2010"),
                new Champions("61#Kha'Zix#Male#2#Void-Being#Mana#13#2012"),
                new Champions("62#Kindred#Other#2#God#Mana#8#2015"),
                new Champions("63#Kled#Male#1#Yordle#Courage#6#2016"),
                new Champions("64#Kog'Maw#Male#4#Void-Being#Mana#13#2010"),
                new Champions("65#LeBlanc#Female#3#Magically Altered#Mana#6#2010"),
                new Champions("66#Lee Sin#Male#2#Human#Energy#4#2011"),
                new Champions("67#Leona#Female#5#Human#Mana#11#2011"),
                new Champions("68#Lillia#Female#2#Spirit#Mana#4#2020"),
                new Champions("69#Lissandra#Female#3#Human#Mana#12#2013"),
                new Champions("70#Lucian#Male#4#Human#Mana#3#2013"),
                new Champions("71#Lulu#Female#5#Yordle#Mana#1#2012"),
                new Champions("72#Lux#Female#5#Human#Mana#3#2010"),
                new Champions("73#Malphite#Male#1#Golem#Mana#10#2009"),
                new Champions("74#Malzahar#Male#3#Void-Being#Mana#13#2010"),
                new Champions("75#Maokai#Male#1#Spirit#Mana#9#2009"),
                new Champions("76#Master Yi#Male#2#Human#Mana#4#2010"),
                new Champions("77#Miss Fortune#Female#4#Human#Mana#2#2010"),
                new Champions("78#Mordekaiser#Male#1#Revenant#Shield#6#2010"),
                new Champions("79#Morgana#Female#5#Magically Altered#Mana#3#2009"),
                new Champions("80#Nami#Female#5#Vastayan#Mana#8#2012"),
                new Champions("81#Nasus#Male#1#God#Mana#10#2009"),
                new Champions("82#Nautilus#Male#5#Revenant#Mana#2#2012"),
                new Champions("83#Neeko#Female#3#Vastayan#Mana#5#2018"),
                new Champions("84#Nidalee#Female#2#Vastayan#Mana#8#2009"),
                new Champions("85#Nilah#Female#4#Magically Altered#Mana#2#2022"),
                new Champions("86#Nocturne#Male#20#Demon#Mana#8#2011"),
                new Champions("87#Nunu & Willump#Male#2#Human#Mana#12#2009"),
                new Champions("88#Olaf#Male#2#Human#Mana#12#2010"),
                new Champions("89#Orianna#Female#3#Golem#Mana#7#2011"),
                new Champions("90#Ornn#Male#1#God#Mana#12#2017"),
                new Champions("91#Pantheon#Male#1#Human#Mana#11#2010"),
                new Champions("92#Poppy#Male#1#Yordle#Mana#3#2010"),
                new Champions("93#Pyke#Male#5#Revenant#Mana#2#2018"),
                new Champions("94#Qiyana#Female#3#Human#Mana#5#2019"),
                new Champions("95#Quinn#Female#1#Human#Mana#3#2013"),
                new Champions("96#Rakan#Male#5#Vastayan#Mana#4#2017"),
                new Champions("97#Rammus#Male#2#God#Mana#10#2009"),
                new Champions("98#Rek'Sai#Female#2#Void-Being#Rage#13#2014"),
                new Champions("99#Rell#Female#5#Magically Altered#Mana#6#2020"),
                new Champions("100#Renata Glasc#Female#5#Chemically Altered#Mana#14#2022"),
                new Champions("101#Renekton#Male#1#God#Fury#10#2011"),
                new Champions("102#Rengar#Male#2#Vastayan#Ferocity#5#2012"),
                new Champions("103#Riven#Female#1#Human#Manaless#4#2011"),
                new Champions("104#Rumble#Male#1#Yordle#Heat#1#2011"),
                new Champions("105#Ryze#Male#3#Magically Altered#Mana#8#2009"),
                new Champions("106#Samira#Female#4#Human#Mana#6#2020"),
                new Champions("107#Sejuani#Female#2#Human#Mana#12#2012"),
                new Champions("108#Senna#Female#5#Human#Mana#3#2019"),
                new Champions("109#Seraphine#Female#5#Human#Mana#7#2020"),
                new Champions("110#Sett#Male#1#Vastayan#Grit#4#2020"),
                new Champions("111#Shaco#Male#2#Spirit#Mana#8#2009"),
                new Champions("112#Shen#Male#1#Human#Energy#4#2010"),
                new Champions("113#Shyvana#Female#2#Magically Altered#Fury#3#2011"),
                new Champions("114#Singed#Male#1#Chemically Altered#Mana#14#2009"),
                new Champions("115#Sion#Male#1#Revenant#Mana#6#2009"),
                new Champions("116#Sivir#Female#4#Human#Mana#10#2009"),
                new Champions("117#Skarner#Male#2#Brackern#Mana#10#2011"),
                new Champions("118#Sona#Female#5#Human#Mana#3#2010"),
                new Champions("119#Soraka#Female#5#Celestial#Mana#11#2009"),
                new Champions("120#Swain#Male#3#Magically Altered#Mana#6#2010"),
                new Champions("121#Sylas#Male#3#Human#Mana#3#2019"),
                new Champions("122#Syndra#Female#3#Human#Mana#4#2012"),
                new Champions("123#Tahm Kench#Male#1#Demon#Mana#2#2015"),
                new Champions("124#Taliyah#Female#2#Human#Mana#10#2016"),
                new Champions("125#Talon#Male#3#Human#Mana#6#2011"),
                new Champions("126#Taric#Male#5#Human#Mana#11#2009"),
                new Champions("127#Teemo#Male#1#Yordle#Mana#1#2009"),
                new Champions("128#Thresh#Male#5#Undead#Mana#9#2013"),
                new Champions("129#Tristana#Female#4#Yordle#Mana#1#2009"),
                new Champions("130#Trundle#Male#2#Troll#Mana#12#2010"),
                new Champions("131#Tryndamere#Male#1#Magically Altered#Fury#12#2009"),
                new Champions("132#Twisted Fate#Male#3#Human#Mana#2#2009"),
                new Champions("133#Twitch#Male#4#Chemically Altered#Mana#14#2009"),
                new Champions("134#Udyr#Male#1#Vastayan#Mana#12#2009"),
                new Champions("135#Urgot#Male#1#Chemically Altered#Mana#6#2010"),
                new Champions("136#Varus#Male#4#Darkin#Mana#8#2012"),
                new Champions("137#Vayne#Female#4#Human#Mana#3#2011"),
                new Champions("138#Veigar#Male#3#Yordle#Mana#1#2009"),
                new Champions("139#Vel'Koz#Male#3#Void-Being#Mana#13#2014"),
                new Champions("140#Vex#Female#3#Yordle#Mana#9#2021"),
                new Champions("141#Vi#Female#2#Human#Mana#14#2012"),
                new Champions("142#Viego#Male#2#Undead#Manaless#9#2021"),
                new Champions("143#Viktor#Male#3#Human#Mana#14#2011"),
                new Champions("144#Vladimir#Male#3#Magically Altered#Bloodthirst#6#2010"),
                new Champions("145#Volibear#Male#1#God#Mana#12#2011"),
                new Champions("146#Warwick#Male#2#Chemically Altered#Mana#14#2009"),
                new Champions("147#Wukong#Male#1#Vastayan#Mana#4#2011"),
                new Champions("148#Xayah#Female#4#Vastayan#Mana#4#2017"),
                new Champions("149#Xerath#Male#3#God#Mana#10#2011"),
                new Champions("150#Xin Zhao#Male#2#Human#Mana#3#2010"),
                new Champions("151#Yasuo#Male#3#Human#Flow#4#2013"),
                new Champions("152#Yone#Male#1#Magically Altered#Manaless#4#2020"),
                new Champions("153#Yorick#Male#1#Magically Altered#Mana#9#2011"),
                new Champions("154#Yuumi#Female#5#Magically Altered#Mana#1#2019"),
                new Champions("155#Zac#Male#2#Golem#Health#14#2013"),
                new Champions("156#Zed#Male#3#Human#Energy#4#2012"),
                new Champions("157#Zeri#Female#4#Human#Mana#14#2022"),
                new Champions("158#Ziggs#Male#3#Yordle#Mana#7#2012"),
                new Champions("159#Zilean#Male#5#Human#Mana#8#2009"),
                new Champions("160#Zoe#Female#3#Human#Mana#11#2017"),
                new Champions("161#Zyra#Female#5#Unknown#Mana#5#2012"),
            });

            modelBuilder.Entity<Lanes>().HasData(new Lanes[]
            {
                new Lanes("1#Top"),
                new Lanes("2#Jungle"),
                new Lanes("3#Middle"),
                new Lanes("4#Bot"),
                new Lanes("5#Support"),
            });

            modelBuilder.Entity<Regions>().HasData(new Regions[]
            {
                new Regions("1#Bandle-City"),
                new Regions("2#Bilgewater"),
                new Regions("3#Demacia"),
                new Regions("4#Ionia"),
                new Regions("5#Ixtal"),
                new Regions("6#Noxus"),
                new Regions("7#Piltover"),
                new Regions("8#Runeterra"),
                new Regions("9#Shadow Isles"),
                new Regions("10#Shurima"),
                new Regions("11#Targon"),
                new Regions("12#Freljord"),
                new Regions("13#Void"),
                new Regions("14#Zaun"),
            });

        }

    }
}
