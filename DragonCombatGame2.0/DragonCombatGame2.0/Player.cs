using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatGame2._0
{
    //create enumerator for the three player attacks
    public enum AttackType { Sword = 1, Magic, Heal, }

    class Player
    {
        //create properties for player
        //one for player's name
        public string Name { get; set; }
        //one for player's starting hp
        public int playerHP { get; set; }
        //one for if they are alive where startingHP > 0
        public bool IsAlive
        {
            get { return this.playerHP > 0; }
        }

        //create constructor for the player
        public Player(string name, int startingHP)
        {
            this.Name = name;
            this.playerHP = startingHP;
        }

        //create methods
        //create a random number generator for the different attacks
        Random rng = new Random();

        //create player choice for attack
        private AttackType ChooseAttack()
        {
            //ask user to choose an attack
            Console.WriteLine("\n\n==============Attacks==============\n\nChoose an attack!\n\n1.  Sword - attacks with sword for 20-35 damage with 70% hit chance\n2.  Magic - attacks with fireball that always hits at 10-15 damage\n3.  Heal - heal yourself for 10-20 HP\n\n");
            Console.WriteLine("Please enter either 1, 2, or 3 and hit ENTER\n");
            //create variable for users choice and turn into integer
            int userChoice = int.Parse(Console.ReadLine());
            //returns the enum depending on the users choice to choose the attack
            return (AttackType)userChoice;
        }

        //create a function for player attack
        public int playerDoAttack()
        {
            //create damage variable
            int damage = 0;
            //run switch conditionals depending on result of ChooseAttack()
            switch (ChooseAttack())
            {
                case AttackType.Sword:
                    //run sword's hit chance
                    int swordChance = rng.Next(0, 101);
                    //sword only attacks 70% of the time
                    if (swordChance >= 30)
                    {
                        //sword attacks anywhere from 20-35 hp
                        int swordDMG = rng.Next(20, 36);
                        //print to user
                        Console.WriteLine("\n==========================================================");
                        Console.WriteLine("\n\nYou attack with your sword and cause " + swordDMG + " damage to the dragon!");
                        damage += swordDMG;
                        return damage;
                    }
                    //if sword hitchance is below 30%, then it misses the dragon
                    else
                    {
                        Console.WriteLine("\n==========================================================");
                        Console.WriteLine("\n\nSorry you missed the dragon with your sword!");
                    }
                    break;
                case AttackType.Magic:
                    //run magic attack at anywhere between 10 and 15 damage and take away from dragon's health
                    //magic attack hits 100% of the time
                    int magicDMG = rng.Next(10, 16);
                    //print to user
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("\n\nYou blast a fireball at the dragon for a total of " + magicDMG + " damage loss!");
                    damage += magicDMG;
                    return damage;
                    break;
                case AttackType.Heal:
                    //run heal to heal player anywhere between 10 and 20 health points
                    //add heal back to player's health
                    int heal = rng.Next(10, 21);
                    //print to user
                    Console.WriteLine("\n\nYou heal yourself for " + heal + " health points!");
                    playerHP += heal;
                    break;
                default:
                    break;
            }
            return damage;
        }
        //create function for taking damage from enemy
        public void TakeDamage(int damage)
        {
            playerHP -= damage;
            //print to user
            Console.WriteLine("\nYou take " + damage + " damage from the dragon!\n");
            Console.WriteLine("\n==========================================================");
        }
    }
}
