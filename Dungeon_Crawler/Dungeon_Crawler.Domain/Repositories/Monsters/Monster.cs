using Dungeon_Crawler.Domain.Repositories.Heroes;
using Dungeon_Crawler.Data.Enums;


namespace Dungeon_Crawler.Domain.Repositories.Monsters
{
    public class Monster
    {
        public string Type { get; set; }
        public int HP { get; set; }
        public int Damage { get; set; }
        public int XP { get; set; }
        public Monster()
        {
            Type = "";
        }

        public virtual void PrintMonsterInfo()
        {
            Console.WriteLine($"MONSTER: {Type}\n" +
                $"HP: {HP} \n" +
                $"XP: {XP} \n" +
                $"DAMAGE: {Damage} \n");
        }

        public List<MonsterType> MonsterGenerator(int numberOfMonsters)
        {
            List<MonsterType> monsters = new();
            Random random = new();

            for(int i = 0; i < numberOfMonsters; i++)
            {
                double randomValue = random.NextDouble();
                MonsterType monsterType;

                if (randomValue < 0.6) 
                {
                    monsterType = MonsterType.Goblin;
                }
                else if (randomValue < 0.9)  
                {
                    monsterType = MonsterType.Brute;
                }
                else 
                {
                    monsterType = MonsterType.Witch;
                }
                monsters.Add(monsterType);
            }
            return monsters;
        }
    }
}
