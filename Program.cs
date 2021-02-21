using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            House house = new House();
            Team team = new Team();
            Console.WriteLine(team.Name);
            Random R = new Random();
            for (int i = 0; i < 6; i++)
            {
                team.W[(R.Next(0, 3))].Build(house, team.TL);
            }
            foreach (var a in team.TL.reports)
            {
                Console.WriteLine(a);
            }
            team.TL.report();
            for (int i = 0; i < 5; i++)
            {
                team.W[R.Next(0, 3)].Build(house, team.TL);
            }
            foreach (var a in team.TL.reports)
            {
                Console.WriteLine(a);
            }

            team.TL.report();

            house.paint();
            Console.ReadKey();
        }
    }
}
