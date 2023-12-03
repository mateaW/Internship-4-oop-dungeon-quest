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
            this.HP = 600;
            this.HPMax = 600;
            this.Damage = 100;
        }

        public void ActivateRage()
        {
            RageMode = true;
            this.Damage *= 2;
            this.HP -= this.HP * (PercentToRage/100);
        }
    }
}
