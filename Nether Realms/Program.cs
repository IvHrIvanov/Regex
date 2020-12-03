using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {

            string patternName = @"[A-z]";
            string patternDigits = @"[-+]?[0-9]+\.?[0-9]*";
            Regex regex = new Regex(patternName);
            Regex regexDmg = new Regex(patternDigits);
            string[] demon = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<Demon> demons = new List<Demon>();

            for (int i = 0; i < demon.Length; i++)
            {
                string currentDemont = demon[i];
                string filter = "0123456789/*+-.";

                int healt = currentDemont.Where(c => !filter.Contains(c)).Sum(c => c);
                double demage = CalculateDemge(regexDmg, currentDemont);

                Demon newDemon = new Demon(currentDemont, healt, demage);
                demons.Add(newDemon);
            }
            foreach (var sortedDemons in demons.OrderBy(x=>x.DemonName))
            {
                Console.WriteLine(sortedDemons);
            }
        }

        private static double CalculateDemge(Regex regexDmg, string currentDemont)
        {

            MatchCollection numberMatches = regexDmg.Matches(currentDemont);
            double demage = 0;
            foreach (Match match in numberMatches)
            {
                demage += double.Parse(match.Value);
            }
            foreach (var ch in currentDemont)
            {
                if (ch == '*')
                {
                    demage *= 2;
                }
                else if (ch == '/')
                {
                    demage /= 2;
                }
            }
            return demage;
        }
    }
    class Demon
    {
        public Demon(string demonName, int health, double demage)
        {
            DemonName = demonName;
            Health = health;
            Demage = demage;
        }

        public string DemonName { get; set; }
        public int Health { get; set; }
        public double Demage { get; set; }

        public override string ToString()
        {

            return $"{DemonName} - {Health} health, {Demage:f2} damage";
        }

    }
}
