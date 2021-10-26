using System;

namespace EpicFight
{
    class Program
    {
        static void Main(string[] args)
        {
            string hero, villain;
            string heroWeapon, villainWeapon;
            hero = RandomHero();
            heroWeapon = RandomWeapon();
            villain = RandomVillain();
            villainWeapon = RandomWeapon();
            int heroHP = GenerateHP(hero);
            int villainHP = GenerateHP(villain);
            Console.WriteLine($"{hero} ({heroHP}HP) will fight {villain} ({villainHP}HP.");
            Console.WriteLine($"{hero} will fight with {heroWeapon}.");
            Console.WriteLine($"{villain} will fight with {villainWeapon}.");

            Console.WriteLine($"{hero} will fight {villain}.");
            Console.WriteLine($"{hero} will fight with {heroWeapon}.");
            Console.WriteLine($"{villain} will fight with {villainWeapon}.");

            while(heroHP > 0 && villainHP > 0)
            {
                heroHP = heroHP - Hit(villain, hero, villainWeapon);
                villainHP = villainHP - Hit(hero, villain, heroWeapon);
            }
            if(heroHP <= 0)
            {
                Console.WriteLine("Dark Side wins!");
            }
            else 
            {
                Console.WriteLine($"{hero} saves the day!");
            }

        }

        private static int Hit(string characterOne, string characterTwo, string weapon)
        {
            Random rnd = new Random();
            int strike = rnd.Next(0, weapon.Length / 2);
            Console.WriteLine($"{characterOne} hit {strike}.");

            if(strike == weapon.Length / 2 - 1)
            {
                Console.WriteLine($"Awesome! {characterOne} made a critical hit!");
            }
            else if(strike == 0)
            {
                Console.WriteLine($"{characterTwo} dodged the attack!");
            }

            return strike;
        }

        private static int GenerateHP(string someCharacter)
        {
            Random rnd = new Random();
            return rnd.Next(someCharacter.Length, someCharacter.Length + 10);
        }

        private static int RandomIndex(string[] someArray)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, someArray.Length);

            return randomIndex;
        }

        private static string RandomHero()
        {
            string[] heroes = { "Batman", "Spongebob", "Spiderman", "Patric", "Lara Croft" };

            return heroes[RandomIndex(heroes)];
        }

        private static string RandomVillain()
        {
            string[] villains = { "Joker", "Darth Vader", "Thanos", "Loki", "T-1000" };
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, villains.Length);

            string randomVillain = villains[randomIndex];
            return randomVillain;
        }

        private static string RandomWeapon()
        {
            string[] weapon = { "foot gun", "plactic fork", "flip-flop", "magic wand", "katana" };

            return weapon[RandomIndex(weapon)];
        }

    }
}
