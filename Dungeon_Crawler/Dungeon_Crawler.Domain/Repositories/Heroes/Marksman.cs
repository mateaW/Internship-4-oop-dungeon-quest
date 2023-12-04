using Dungeon_Crawler.Data.Enums;

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
            // at the beggining possibilities of these two s 10%
            this.CriticChance = 0.1;
            this.StunChance = 0.1;
        }

        public bool PossibilityOfCriticalChance()
        {
            Random random = new();
            if(CriticChance >= random.NextDouble()) 
            {
                return true; // if possibility of critical chance is greater than a random percent player can use it
            }
            else
            {
                return false;
            }
        }

        public void HandleCriticalHit()
        {
            Damage *= 2;
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
        public void HandleStunHit()
        {
            // cudoviste gubi rundu
        }

        public override void LevelUp()
        {
            base.LevelUp();
            // possibilities grow with level up for 10%
            CriticChance += 0.1;
            StunChance += 0.1;
        }

    }
}
