using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05ZooFull
{
    class Animal
    {
        string name;
        string species;
        int age;
        double weight;

        public Animal(string name, string species, int age, double weight)
        {
            Name = name;
            Species = species;
            Age = age;
            Weight = weight;
        }

        public string Name { get => name; set => name = value; }
        public string Species { get => species; set => species = value; }
        public int Age { get => age; set => age = value; }
        public double Weight { get => weight; set => weight = value; }

        public static void checkAgeValid(int age)
        {
            if (age < 0 || age > 500)
            {
                throw new ArgumentOutOfRangeException("Age must be 0-500");
            }
        }
        public static void checkNameValid(string name)
        {
            if (name.Length < 2 )
            {
                throw new ArgumentOutOfRangeException("Name must be at least 2 characters long");
            }
        }
        public static void checkWeightValid(double weight)
        {
            if(weight <0 || weight > 100000)
            {
                throw new ArgumentOutOfRangeException("Weight must be between 0-100000 lb");
            }
        }      

        public static void checkSpeciesValid(string species)
        {
            String[] allSpecies = { "Lion", "Elephant", "Hippo", "Ape", "Zebra", "Bird" };
            bool match = false;
            for(int i = 0; i < allSpecies.Length; i++)
            {
                if(allSpecies[i] == species)
                {
                    match = true;
                }
            }
            if(match == false)
            {
                throw new ArgumentOutOfRangeException("INVALID SPECIES");
            }
        }

        public override string ToString()
        {
            return Name+";"+Species+";"+Age+";"+Weight;
        }
    }
}
