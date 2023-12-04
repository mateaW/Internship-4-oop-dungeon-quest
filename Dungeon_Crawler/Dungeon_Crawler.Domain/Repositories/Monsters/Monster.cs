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
            // different values for HP,XP,Damage for every monster
        }

        public virtual void Attack(Hero hero)
        {
            // there will be different logic for attack for every monster
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
            // generates how much we want monsters and puts them in a list

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
