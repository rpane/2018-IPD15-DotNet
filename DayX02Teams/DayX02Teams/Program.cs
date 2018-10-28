using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayX02Teams
{
    class Program
    {
        
        static void Main(string[] args)
        {
            SortedDictionary<string, Team> fifa = new SortedDictionary<string, Team>();
            fifa.Clear();
            try
            {
                string[] lineArray = File.ReadAllLines(@"..\..\teams.txt");
                
                foreach (string line in lineArray)
                {
                    string[] split = line.Split(';');
                    try
                    {
                        Team x = new Team(split[0]);
                        Team y = new Team(split[1]);
                        fifa.Add(split[0],x);
                        fifa.Add(split[1], y);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("An element with Key = "+split[0]+" already exists.");
                    }

                    fifa[split[0]].GoalsShot += int.Parse(split[2]);
                    fifa[split[1]].GoalsShot += int.Parse(split[3]);
                    if(int.Parse(split[2])> int.Parse(split[3]))
                    {
                        fifa[split[0]].GamesWon++;
                        fifa[split[1]].GamesLost++;
                    }
                    else
                    {
                        fifa[split[1]].GamesWon++;
                        fifa[split[0]].GamesLost++;
                    }

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
            foreach(KeyValuePair<string, Team> kvp in fifa)
            {
                Console.WriteLine("Team = {0}, Games Won = {1}, Games Lost = {2}, Goals Shot = {3}",
                kvp.Key, kvp.Value.GamesWon, kvp.Value.GamesLost, kvp.Value.GoalsShot);
            }
            Console.WriteLine("----------------------------------Order by Games Won-----------------------");
            var gamesWon = fifa.OrderByDescending(x => x.Value.GamesWon);
            foreach( var x in gamesWon)
            {
                Console.WriteLine("Team = {0}, Games Won = {1}, Games Lost = {2}, Goals Shot = {3}",
                x.Key, x.Value.GamesWon, x.Value.GamesLost, x.Value.GoalsShot);
            }

            Console.ReadKey();
        }
    }
}
