namespace Dungeon_Crawler.Domain.Repositories
{
    public class Marksman : Hero
    {
        public int CriticalChance { get; set; }
        public int StunChance { get; set; }

        public Marksman(string ime, int healthPoints, int experience, int damage, int level, int criticalChance, int stunChance)
            : base(ime, healthPoints, experience, damage, level)
        {
            CriticalChance = criticalChance;
            StunChance = stunChance;
        }

        public override void AttackMonster()
        {
        }
    }
}
