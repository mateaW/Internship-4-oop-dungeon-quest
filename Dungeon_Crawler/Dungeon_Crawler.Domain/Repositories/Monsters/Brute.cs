using Dungeon_Crawler.Domain.Repositories.Heroes;

namespace Dungeon_Crawler.Domain.Repositories.Monsters
{
    public class Brute : Monster
    {
        public Brute() : base()
        {
            Random random = new();
            this.Type = "Brute";
            this.HP = random.Next(1, 21);
            this.XP = random.Next(1, 11);
            this.Damage = random.Next(1, 16);
        }
        public bool TakingPercentageOfLife()
        {
            Random random = new ();
            double possibility = random.NextDouble();
            if(possibility >= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BruteAttack(Hero hero)
        {
            Console.WriteLine($"Brute napada.");
            if (TakingPercentageOfLife())
            {
                Console.WriteLine("Oduzeo vam je 50% života.");
                hero.HP /= 2; 
            }
            else
            {
                Console.WriteLine($"Oduzeo vam je {Damage} hp-a.");
                hero.HP -= this.Damage;
            }
            Console.WriteLine();
            hero.PrintHeroInfo();
            Console.WriteLine();
            PrintMonsterInfo();
        }
    }
}
