using Dungeon_Crawler.Data.Enums;
using Dungeon_Crawler.Domain.Repositories.Monsters;

namespace Dungeon_Crawler.Domain.Repositories.Heroes
{
    public class Gladiator : Hero
    {
        public bool RageMode { get; set; }
        public int PercentToRage { get; set; }

        public Gladiator(string Name) : base(Name)
        {
            this.Type = "Gladiator";
            RageMode = false;
            PercentToRage = 15;
            this.HP = (int)HeroHP.Gladiator;
            this.HPMax = HP;
            Damage = (int)HeroDamage.Gladiator;
        }

        public void GladiatorAttack(Monster monster)
        {
            while (true)
            {
                Console.WriteLine("Želite li napasti iz bijesa za 15 HP-a \n" +
                "i time napraviti dupli damage.(da/ne)?");
                var answer = Console.ReadLine()!;
                if (answer.ToLower() == "da")
                {
                    monster.HP -= ActivateRage();
                    GetExperience(monster.XP);
                    break;
                }
                else if (answer.ToLower() == "ne")
                {
                    monster.HP -= Damage;
                    GetExperience(monster.XP);
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos.");
                    continue;
                }
            }
            Console.WriteLine();
            PrintHeroInfo();
            Console.WriteLine();
            monster.PrintMonsterInfo();
        }

        public int ActivateRage() 
        {
            // we ask the player before if he wants to fight with rage
            // through interface
            RageMode = true;
            HP -= 15;
            int d = Damage;
            return d *= 2; //double damage
            // he then spends 15% of his hp
        }
    }
}
