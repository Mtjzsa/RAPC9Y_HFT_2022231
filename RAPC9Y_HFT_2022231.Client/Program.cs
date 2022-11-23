using ConsoleTools;
using RAPC9Y_HFT_2022231.Models;
using System;
using System.Collections.Generic;

namespace RAPC9Y_HFT_2022231.Client
{
    public class Program
    {
        static RestService rest;

        static void List(string entity)
        {
            if (entity=="Champions")
            {
                List<Champions> champs = rest.Get<Champions>("champion");
                foreach (var item in champs)
                {
                    Console.WriteLine(item.Id+" "+item.Name);
                }
            }
            if (entity == "Lanes")
            {
                List<Lanes> champs = rest.Get<Lanes>("lane");
                foreach (var item in champs)
                {
                    Console.WriteLine(item.Id+" "+item.LaneName);
                }
            }
            if (entity == "Regions")
            {
                List<Regions> champs = rest.Get<Regions>("region");
                foreach (var item in champs)
                {
                    Console.WriteLine(item.Id+" "+item.RegionName);
                }
            }
            Console.ReadLine();
        }
        static void Create(string entity)
        {
            if (entity=="Champions")
            {
                Console.Write("Enter Champion Name:");
                string name = Console.ReadLine();
                rest.Post(new Champions() { Name = name }, "champion");

            }
            if (entity == "Lanes")
            {
                Console.Write("Enter Lane Name:");
                string name = Console.ReadLine();
                rest.Post(new Lanes() { LaneName = name }, "lane");

            }
            if (entity == "Regions")
            {
                Console.Write("Enter Region Name:");
                string name = Console.ReadLine();
                rest.Post(new Regions() { RegionName = name }, "region");

            }
        }
        static void Update(string entity)
        {
            if (entity=="Champions")
            {
                Console.Write("Enter Champion's id to update:");
                int id = int.Parse(Console.ReadLine());
                Champions first = rest.Get<Champions>(id, "champion");
                Console.Write($"New name [old: {first.Name}]: ");
                string name = Console.ReadLine();
                first.Name = name;
                rest.Put(first, "champion");
            }
            if (entity == "Lanes")
            {
                Console.Write("Enter Lane's id to update:");
                int id = int.Parse(Console.ReadLine());
                Lanes first = rest.Get<Lanes>(id, "lane");
                Console.Write($"New name [old: {first.LaneName}]: ");
                string name = Console.ReadLine();
                first.LaneName = name;
                rest.Put(first, "lane");
            }
            if (entity == "Regions")
            {
                Console.Write("Enter Region's id to update:");
                int id = int.Parse(Console.ReadLine());
                Regions first = rest.Get<Regions>(id, "region");
                Console.Write($"New name [old: {first.RegionName}]: ");
                string name = Console.ReadLine();
                first.RegionName = name;
                rest.Put(first, "region");
            }
        }
        static void Delete(string entity)
        {
            if (entity=="Champions")
            {
                Console.WriteLine("Enter Champion's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "champion");
            }
            if (entity == "Lanes")
            {
                Console.WriteLine("Enter Lane's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "lane");
            }
            if (entity == "Regions")
            {
                Console.WriteLine("Enter Region's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "region");
            }
        }
        static void NonManaIonianChamps()
        {
            Console.WriteLine("NonMana Users From Ionia Released After 2010:");
            List<Champions> list = rest.Get<Champions>("Stat/IonianChampionsWithoutManaAfter2010");
            foreach (var item in list)
            {
                Console.WriteLine(item.Id+". "+item.Name+": "+item.Resources+", "+item.Release);
            }
            Console.ReadLine();
        }
        static void FemaleDemacian()
        {
            Console.WriteLine("Female Champs From Demacia:");
            List<Champions> list = rest.Get<Champions>("Stat/FemaleDemacianChampions");
            foreach (var item in list)
            {
                Console.WriteLine(item.Id+". "+item.Name);
            }
            Console.ReadLine();
        }
        static void OtherSupps()
        {
            Console.WriteLine("Support Champions With Other Gender:");
            List<Champions> list = rest.Get<Champions>("Stat/SupportWithOtherGender");
            foreach (var item in list)
            {
                Console.WriteLine(item.Id+". "+item.Name);
            }
            Console.ReadLine();
        }
        static void TopChamps()
        {
            Console.WriteLine("Top Champions Ordered By Release:");
            List<Champions> list = rest.Get<Champions>("Stat/TopChampionsOrderByRelease");
            foreach (var item in list)
            {
                Console.WriteLine(item.Id+". "+item.Name+", "+item.Release);
            }
            Console.ReadLine();
        }
        static void RegionInfo()
        {
            Console.WriteLine("Region infos:");
            List<Regions.RegionInfo> list= rest.Get<Regions.RegionInfo>("Stat/RegionInfo");
            foreach (var item in list)
            {
                Console.WriteLine("RegionName: "+item.Region);
                Console.WriteLine("AverageRelease: "+item.Year);
                Console.WriteLine("NumberOfChamps: "+item.Number);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:39827/", "champion"); 
            
            
            var championSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Champions"))
                .Add("Create", () => Create("Champions"))
                .Add("Delete", () => Delete("Champions"))
                .Add("Update", () => Update("Champions"))
                .Add("Exit", ConsoleMenu.Close);

            var laneSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Lanes"))
                .Add("Create", () => Create("Lanes"))
                .Add("Delete", () => Delete("Lanes"))
                .Add("Update", () => Update("Lanes"))
                .Add("Exit", ConsoleMenu.Close);

            var regionSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Regions"))
                .Add("Create", () => Create("Regions"))
                .Add("Delete", () => Delete("Regions"))
                .Add("Update", () => Update("Regions"))
                .Add("Exit", ConsoleMenu.Close);

            var statSubMenu = new ConsoleMenu(args, level: 1)
                .Add("NonMana Users from Ionia After 2010", () => NonManaIonianChamps())
                .Add("Female Champs From Demacia", () => FemaleDemacian())
                .Add("Other Gender Supps", ()=>OtherSupps())
                .Add("Top Champs Ordered By Release", () =>TopChamps())
                .Add("All Regions Info", () =>RegionInfo())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Champions", () => championSubMenu.Show())
                .Add("Lanes", () => laneSubMenu.Show())
                .Add("Regions", () => regionSubMenu.Show())
                .Add("Non-CRUDS", () => statSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            
            menu.Show();
        }
    }
}
