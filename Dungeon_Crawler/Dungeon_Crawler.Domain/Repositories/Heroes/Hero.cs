using Dungeon_Crawler.Domain.Repositories.Monsters;

namespace Dungeon_Crawler.Domain.Repositories.Heroes
{
    public abstract class Hero
    {
        public string Name { get; set; }

        public string Type { get; set; }
        public int HP { get; set; }
        public int HPMax { get; set; }

        public int XP { get; set; }
        public int XPMax { get; set; }

        public int Damage { get; set; }
        public int Level { get; set; }

        public Hero(string name)
        {
            Name = name;
            Type = "";
            XP = 0;
            XPMax = 100;
            Level = 1;
        }

        public void GetExperience(int xpGained)
        {
            XP += xpGained;

            if (XP >= XPMax)
            {
                LevelUp();
                XP -= XPMax;
            }
        }

        public void LevelUp()
        {
            Level++;
            Console.WriteLine("POSTIGLI STE NOVI LEVEL. \n" +
                $"NOVI LEVEL JE: {Level}");
            HP += 15;
            Damage += 5;
            Console.WriteLine($"HP: {HP}\n" +
                $"XP: {XP}" +
                $"DAMAGE: {Damage}");

        }

        public void AttackMonster(Monster monster)
        {

        }

        public void PrintInfo()
        {
            Console.WriteLine($"HERO: {Name}\n" +
                $"LEVEL: {Level}\n" +
                $"HP: {HP} \n" +
                $"XP: {XP} \n" +
                $"DAMAGE: {Damage} \n");
        }

    }
}

