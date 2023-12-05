using Dungeon_Crawler.Domain.Repositories.Monsters;

namespace Dungeon_Crawler.Domain.Repositories.Heroes
{
    public class Hero
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
            Type = "vlastiti heroj";
            XP = 0;
            XPMax = 100;
            HPMax = HP;
            Level = 1;
        }
        public void HeroAttack(Monster monster)
        {
            Console.WriteLine("Napali ste čudovište i smanjili mu HP za " +
                $"{Damage} bodova.\n" +
                $"Dobili ste {monster.XP} XP-a.");
            monster.HP -= Damage;
            GetExperience(monster.XP);
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

        public virtual void LevelUp()
        {
            Level++;
            Console.WriteLine("Postigli ste novi level. \n" +
                $"Novi level je: {Level}\n");
            HP += 15; 
            Damage += 5;
            PrintHeroInfo();
        }

        public virtual void PrintHeroInfo()
        {
            Console.WriteLine("Trenutni podaci o vašem heroju.");
            Console.WriteLine($"HERO: {Name}\n" +
                $"TYPE: {Type}\n" +
                $"LEVEL: {Level}\n" +
                $"HP: {HP}/{HPMax} \n" +
                $"XP: {XP}/{XPMax} \n" +
                $"DAMAGE: {Damage}");
        }
    }
}

