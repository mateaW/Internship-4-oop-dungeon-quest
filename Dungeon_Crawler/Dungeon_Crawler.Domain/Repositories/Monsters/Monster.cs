using Dungeon_Crawler.Domain.Repositories.Heroes;
using Dungeon_Crawler.Data.Enums;
using System.Security.AccessControl;

namespace Dungeon_Crawler.Domain.Repositories.Monsters
{
    public abstract class Monster
    {
        public string Type { get; set; }
        public int HP { get; set; }
        public int HPMax { get; set; }
        public int Damage { get; set; }
        public int XP { get; set; }
        public Monster()
        {
            Type = "";
        }
        public void Attack(Hero hero)
        {
        }

        public void PrintMonsterInfo()
        {
            Console.WriteLine($"HERO: {Type}\n" +
                $"HP: {HP} \n" +
                $"XP: {XP} \n" +
                $"DAMAGE: {Damage} \n");
        }

        public List<MonsterType> MonsterGenerator(int numberOfMonsters)
        {
            List<MonsterType> monsters = new List<MonsterType>();
            Random random = new();

            for(int i = 0; i < numberOfMonsters; i++)
            {
                double randomValue = random.NextDouble();
                MonsterType monsterType;

                if (randomValue < 0.6)  // 60% chance for Goblin
                {
                    monsterType = MonsterType.Goblin;
                }
                else if (randomValue < 0.9)  // 30% chance for Brute
                {
                    monsterType = MonsterType.Brute;
                }
                else  // 10% chance for Witch
                {
                    monsterType = MonsterType.Witch;
                }
                monsters.Add(monsterType);
            }
            return monsters;
        }
    }
}
