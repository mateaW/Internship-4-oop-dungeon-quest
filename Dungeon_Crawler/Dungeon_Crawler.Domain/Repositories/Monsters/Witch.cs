using Dungeon_Crawler.Domain.Repositories.Heroes;

namespace Dungeon_Crawler.Domain.Repositories.Monsters
{
    public class Witch : Monster
    {
        public Witch() : base()
        {
            Random random = new();
            this.Type = "Witch";
            this.HP = random.Next(1,21);
            this.XP = random.Next(1, 11);
            this.Damage = random.Next(1, 21);
        }

        public void MakeTwoNewMonsters()
        {
            Console.WriteLine("Porazili ste čudovište Witch. Što znači da se morate boriti\n " +
                "protiv sljedeća dva novo generirana čudovišta.");
            MonsterGenerator(2);
        }

        static bool CurseProbability()
        {
            Random random = new();
            double curseProbability = random.NextDouble();
            if(curseProbability >= 0.5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void WitchAttack(Hero hero)
        {
            if (CurseProbability())
            {
                Random random = new();
                hero.HP = random.Next(1, 6);
                Console.WriteLine($"Witch je iskoristila specijalnu moć đumbus." +
                    $"HP vam je postavljen na nasumičnu vrijednost od: {hero.HP}");
            }
            else
            {
                Console.WriteLine($"Witch napada. Oduzeto vam je {Damage} hp-a.");
                hero.HP -= Damage;
            }
            Console.WriteLine();
            hero.PrintHeroInfo();
            Console.WriteLine();
            PrintMonsterInfo();
        }

    }
}
