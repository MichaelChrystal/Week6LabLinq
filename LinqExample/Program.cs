using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
 public class Player
    {
        Guid _id;
        string _name;
        int _xp;

        
            public Guid Id { get; set; }
        public string Name { get; set; }
        public int Xp { get; set; }

        public override string ToString()
        {
            return Id.ToString() + " " + Name.ToString() + " " + Xp.ToString();



    }

    class Program
    {

      static  List<Player> Players = new List<Player>()
            {
                new Player {Id = Guid.NewGuid(), Name = "Michael Chrystal", Xp=100 },
                new Player {Id = Guid.NewGuid(), Name = "Michael Christie", Xp=200 },
                new Player {Id = Guid.NewGuid(), Name = "Jane Doe", Xp=300 },
            };

            static void Main(string[] args)
            {
                // return the first occurance of the match or null
                Player found = Players.FirstOrDefault(p => p.Name == "Michael Chrystal");
                if (found != null)
                    Console.WriteLine("{0}", found.ToString());
                else Console.WriteLine("Not found");

                Console.WriteLine("1=============================");

                // return the first occurance of some of the records
                Player found1 = Players.FirstOrDefault(p => p.Name.Contains("Michael "));
                if (found1 != null)
                    Console.WriteLine("First found {0}", found1.ToString());
                else Console.WriteLine("Not found");

                Console.WriteLine("2=============================");

                //return all thwe players with xp > 100

                List<Player> topPlayers = Players.Where(plr => plr.Xp >= 200).ToList();
                if (topPlayers.Count > 0)
                    foreach (var item in topPlayers)
                    {
                        Console.WriteLine("{0}", item.ToString());
                    }
                Console.WriteLine("3=============================");

                var ScoreBord = Players.OrderByDescending(o => o.Xp)
                                .Select(scores => new { scores.Name, scores.Xp });
                Console.WriteLine("Top Scores");
                foreach (var item in ScoreBord)
                {
                    Console.WriteLine("{0} {1}", item.Name, item.Xp);
                }

            }
            
        }
    }
}
