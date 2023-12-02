namespace Dungeon_Crawler.Domain.Repositories
{
    public class Gladiator : Hero
    {
        public bool RageMode { get; set; }
        public Gladiator(string ime, int healthPoints, int experience, int damage, int level)
        : base(ime, healthPoints, experience, damage, level)
        {
            RageMode = false;
        }

        public override void AttackMonster()
        {
            if (RageMode)
            {
                 // fight with rage mode where damage is double
            }
            else
            {
                // fight without rage mode
            }
            RageMode = false;
        }

        public void ActivateRageMode()
        {
            // check if there is enough hp to fight with rage
            if (HealthPoints <= 0.15 * HealthPoints)
            {
                RageMode = true;
            }
            else
            {
                // print that rage is not activated
            }
        }
    }
}
