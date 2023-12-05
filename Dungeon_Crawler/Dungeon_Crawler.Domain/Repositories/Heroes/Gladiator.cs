using Dungeon_Crawler.Data.Enums;
using Dungeon_Crawler.Domain.Repositories.Monsters;

namespace Dungeon_Crawler.Domain.Repositories.Heroes
{
    public class Gladiator : Hero
    {
        public bool RageMode { get; set; }
        public int HealthForRage { get; set; }

        public Gladiator(string Name) : base(Name)
        {
            this.Type = "Gladiator";
            RageMode = false;
            HealthForRage = 15;
            this.HP = (int)HeroHP.Gladiator;
            this.HPMax = HP;
            Damage = (int)HeroDamage.Gladiator;
        }

        public void GladiatorAttack(Monster monster)
        {
            while (true)
            {
                Console.WriteLine("Želite li napasti iz bijesa" +
                "i time napraviti dupli damage\n" +
                "u zamijenu za 15 HP-a.(da/ne)?\n");

                var answer = Console.ReadLine()!;
                if (answer.ToLower() == "da")
                {
                    int d = ActivateRage();
                    Console.WriteLine("Napali ste iz bijesa. Potrošili ste 15 HP-a\n" +
                        $"te dobili {monster.XP} XP-a");
                    Console.WriteLine($"Čudovištu ste smanjili HP za {d}");
                    monster.HP -= d;
                    GetExperience(monster.XP);
                    break;
                }
                else if (answer.ToLower() == "ne")
                {
                    Console.WriteLine($"Odlučili ste se za običan napad. Dobili ste {monster.XP} XP-a\n" +
                        $"te ste čudovištu smanjili HP za {Damage}");
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
            RageMode = true;
            HP -= 15;
            int d = Damage;
            return d *= 2;
        }
    }
}
