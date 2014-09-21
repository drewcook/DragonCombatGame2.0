using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatGame2._0
{
    class Enemy
    {
        //create properties
        //one for the enemy name
        public string Name { get; set; }
        //one fot the enemy starting HP
        public int dragonHP { get; set; }
        //read-only boolean that returns true if HP>0
        public bool IsAlive
        {
            get { return this.dragonHP > 0; }
        }

        //create the constructor that takes in the Name and starting HP
        public Enemy(string name, int startingHP)
        {
            this.Name = name;
            this.dragonHP = startingHP;
        }

        //create methods now
        //create function for enemy attacking player
        public int enemyDoAttack()
        {
            //create random number generator
            Random rng = new Random();
            //create damage variable
            int damage = 0;

            //print to user
            Console.WriteLine("The dragon begins to attack...\n");
            Console.WriteLine("\n==========================================================");
            int dragonChance = rng.Next(0, 101);
            if (dragonChance >= 20)
            {
                int dragonAttack = rng.Next(5, 16);
                Console.WriteLine("\n\nThe dragon hits with his fiery breath for a total of " + dragonAttack + " damage!");
                damage += dragonAttack;
                return damage;
                Console.WriteLine("\n==========================================================");
            }
            else
            {
                Console.WriteLine("\n\nThe dragon misses you with his fiery breath!  You barely scrape by to fight again!");
            }
            return damage;
        }
        //create function for taking damage from player
        public void TakeDamage(int damage)
        {
            dragonHP -= damage;
            //print to user
            Console.WriteLine("\nThe dragon takes " + damage + " damage from the player!\n");
        }
    }
}
