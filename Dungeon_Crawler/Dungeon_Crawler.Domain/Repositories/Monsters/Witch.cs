namespace Dungeon_Crawler.Domain.Repositories.Monsters
{
    public class Witch : Monster
    {
        public Witch()
        {
            Random random = new();
            this.Type = "Witch";
            this.HP = random.Next(1,21);
            this.XP = random.Next(1, 11);
            this.Damage = random.Next(1, 21);
        }

        public void MakeTwoNewMonsters()
        {
            MonsterGenerator(2);
        }

        public bool CurseProbability()
        {
            Random random = new();
            double curseProbability = random.NextDouble();
            if(curseProbability >= 50)
            {
                return true;
                // everyone loses health
            }
            else
            {
                return false;
            }
        }

    }
}
