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
        int gamesWon;
        int gamesLost;
        int goalsShot;
        static void Main(string[] args)
        {
            SortedDictionary< Team, string> fifa = new SortedDictionary<Team, string>();
            try
            {
                string[] lineArray = File.ReadAllLines("teams.txt");
                foreach (string line in lineArray)
                {
                    string[] split = line.Split(';');
                
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
