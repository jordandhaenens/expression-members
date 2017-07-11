using System;
using System.Collections.Generic;

namespace expression_members
{
    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public ICollection<string> Predators { get; } = new List<string>();
        public ICollection<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        public string FormalName => $"{this.Name} the {this.Species}";

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        // Convert this method to an expression member
        
        public string PreyList() => string.Join(", ", this.Prey);
        // public string PreyList()
        // {
        //     var commaDelimitedPrey = string.Join(", ", this.Prey);
        //     return commaDelimitedPrey;
        // }

        // Convert this method to an expression member
        public string PredatorList()
        {
            var commaDelimitedPredators = string.Join(",", this.Predators);
            return commaDelimitedPredators;
        }

        // Convert this to expression method (hint: use a C# ternary)
        public string Eat(string food)
        {
            if (this.Prey.Contains(food))
            {
                return $"{this.Name} ate the {food}.";
            } else {
                return $"{this.Name} is still hungry.";
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> predators = new List<string>();
            predators.Add("human feet");
            predators.Add("birds");
            Bug Johnny = new Bug("Johnny", "Mantis", predators, new List<string>(){"aphids", "water"});
            Console.WriteLine(Johnny.PreyList());
        }
    }
}
