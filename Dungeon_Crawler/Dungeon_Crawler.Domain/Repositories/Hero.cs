namespace Dungeon_Crawler.Domain.Repositories
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int HealthPoints { get; set; }

        public int Experience { get; set; }

        public int Damage { get; set; }

        public int Level { get; set; }

        public Hero(string name, int healthPoints, int experience, int damage, int level)
        {
            Name = name;
            HealthPoints = healthPoints;
            Experience = experience;
            Damage = damage;
            Level = level;
        }

        public virtual void GetExperience(int xpGained)
        {
            Experience += xpGained;

            if (Experience >= 100)
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            Level++;
            HealthPoints += 15;
            Damage += 5;
            Experience %= 100;
        }

        public abstract void AttackMonster();
    }
}
