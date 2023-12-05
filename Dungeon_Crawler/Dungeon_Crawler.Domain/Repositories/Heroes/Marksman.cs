using Dungeon_Crawler.Data.Enums;
using Dungeon_Crawler.Domain.Repositories.Monsters;

namespace Dungeon_Crawler.Domain.Repositories.Heroes
{
    public class Marksman : Hero
    {
        public double CriticChance { get; set; }
        public double StunChance { get; set; }

        public Marksman(string name) : base(name)
        {
            this.Damage = (int)HeroDamage.Marksman;
            this.HP = (int)HeroHP.Marksman;
            this.HPMax = HP;
            this.Type = "Marksman";
            this.CriticChance = 0.1;
            this.StunChance = 0.1;
        }

        public void MarksmanAttack(Monster monster)
        {
            if(PossibilityOfCriticalChance())
            {
                int d = HandleCriticalHit();
                Console.WriteLine("Napadate uz pomoć svojstva Critical Hit.");
                Console.WriteLine($"Radite dupli damage te ste oštetili čudovište za {d} HP-a.");
                Console.WriteLine($"Time ste dobili {monster.XP} XP-a.");
                monster.HP -= d;
                GetExperience(monster.XP);
            }
            else if(PossibilityOfStunChance())
            {
                Console.WriteLine("Napadate uz pomoć svojstva Stun Chance što znači da čudovište automatski gubi.");
            }
            else
            {
                Console.WriteLine("Niste ostvarili vjerojatnost za dodatne mogućnosti pa napadate normalno.");
                Console.WriteLine("Napali ste čudovište i smanjili mu HP za " +
                     $"{Damage} bodova.\n" +
                     $"Dobili ste {monster.XP} XP-a.");
                monster.HP -= Damage;
                GetExperience(monster.XP);
            }
            Console.WriteLine();
            this.PrintHeroInfo();
            Console.WriteLine();
            monster.PrintMonsterInfo();
        }
        public bool PossibilityOfCriticalChance()
        {
            Random random = new();
            if(CriticChance >= random.NextDouble()) 
            {
                return true; 
            }
            else
            {
                return false;
            }
        }

        public int HandleCriticalHit()
        {
            int d = Damage * 2;
            return d;
        }

        public bool PossibilityOfStunChance()
        {
            Random random = new();
            if (StunChance >= random.NextDouble())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void LevelUp()
        {
            base.LevelUp();
            CriticChance += 0.1;
            StunChance += 0.1;
        }

    }
}
