using Dungeon_Crawler.Data.Enums;

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
            this.Damage = (int)HeroDamage.Gladiator;
        }

        public void ActivateRage() 
        {
            // we ask the player before if he wants to fight with rage
            // through interface
            RageMode = true;
            this.Damage *= 2; //double damage
            this.HP -= this.HP * (PercentToRage/100); // he then spends 15% of his hp
        }
    }
}
