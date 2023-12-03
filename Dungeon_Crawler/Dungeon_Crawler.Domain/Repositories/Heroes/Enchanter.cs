namespace Dungeon_Crawler.Domain.Repositories.Heroes
{
    public class Enchanter : Hero
    {
        public int Mana { get; set; }

        public int MaxMana { get; set; }

        public bool CanRevive { get; set; }

        public Enchanter(string Name) : base(Name)
        {
            Mana = 200;
            MaxMana = 200;
            this.Type = "Enchanter";
            this.HP = 400;
            this.HPMax = 400;
            this.Damage = 200;

        }
        public void Heal()
        {
            if (Mana >= 50)
            {
                this.HP += 250;
                Mana -= 50;
                this.PrintInfo();
            }
        }

        public void Revive()
        {
            HP = HPMax;
            Mana = MaxMana;
            CanRevive = false;
        }
    }
}
