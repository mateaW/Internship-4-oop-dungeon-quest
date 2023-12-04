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
            MonsterGenerator(2);
        }

        public bool CurseProbability()
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
                    $"HP vam je postavljen na nasumičnu vrijednost: {hero.HP}");
            }
            else
            {
                Console.WriteLine($"Witch napada. Oduzeto vam je {Damage} hp-a.");
                hero.HP -= Damage;
            }
        }

    }
}
