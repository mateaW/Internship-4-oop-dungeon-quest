namespace Dungeon_Crawler.Domain.Repositories
{
    public class Enchanter : Hero
    {
        public int Mana { get; set; }

        public Enchanter(string ime, int healthPoints, int experience, int damage, int level, int mana)
            : base(ime, healthPoints, experience, damage, level)
        {
            Mana = mana;
        }

        public override void AttackMonster()
        {
        }
    }
}
