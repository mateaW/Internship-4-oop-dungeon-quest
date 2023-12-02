namespace Dungeon_Crawler.Domain.Repositories
{
    public abstract class Monster
    {
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
        public int ExperienceValue { get; set; }
        public Monster(int healthPoints, int damage, int experienceValue)
        {
            HealthPoints = healthPoints;
            Damage = damage;
            ExperienceValue = experienceValue;
        }
        public abstract void AttackHero();
    }
}
