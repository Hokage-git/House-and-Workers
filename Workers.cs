using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    interface IWorker
    {
        string Name { get; }
    }
    class Worker : IWorker
    {
        public string Name { get; set; }
        public Worker(string name) { Name = name; }
        string IWorker.Name => Name;
        public void Build(House house, TeamLeader TL)
        {
            if(house.basement == null)
            {
                Basement basement = new Basement();
                basement.Do(house);
                TL.reports.Add($"Worker {Name} has built a basement");
            }else if(house.walls == null || house.walls.Count < 4)
            {
                if (house.walls == null) house.walls = new List<Walls>();
                Walls wall = new Walls();
                wall.Do(house);
                TL.reports.Add($"Worker {Name} builded is wall {house.walls.Count}!");
            }else if(house.door == null)
            {
                Door door = new Door();
                door.Do(house);
                TL.reports.Add($"Worker {Name} builded is door!");
            }else if (house.windows == null || house.windows.Count < 4)
            {
                if (house.windows == null) house.windows = new List<Windows>();
                Windows window = new Windows();
                window.Do(house);
                TL.reports.Add($"Worker {Name} builded is window {house.windows.Count}!");
            }else if (house.roof == null)
            {
                Roof roof = new Roof();
                roof.Do(house);
                TL.reports.Add($"Worker {Name} builded is roof!");

            }
        }
    }
    class Team : IWorker
    {
        public TeamLeader TL;
        public List<Worker> W;
        public string Name { get => "Stroy Masters"; }

        public Team()
        {
            TL = new TeamLeader("Augustin");
            W = new List<Worker> { new Worker("Vlad"), new Worker("Charly"), new Worker("Stanly"), new Worker("Willy") };
        }
    }
    class TeamLeader : IWorker 
    {
        public string Name { get; set; }
        public List<string> reports = new List<string>();
        string IWorker.Name => Name;
        public TeamLeader(string name)
        { Name = name; }

        public void report()
        {
            if (reports.Count == 11) Console.WriteLine("House is done");
            else Console.WriteLine("The house is still under construction");
        }
    }

}
