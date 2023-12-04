﻿using Dungeon_Crawler.Domain.Repositories.Monsters;

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
            Type = "";
            XP = 0;
            XPMax = 100;
            HPMax = HP;
            Level = 1;
        }
        public void HeroAttack(Monster monster)
        {
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
            Console.WriteLine("POSTIGLI STE NOVI LEVEL. \n" +
                $"NOVI LEVEL JE: {Level}");
            // same for every type of hero
            HP += 15; 
            Damage += 5; 
            Console.WriteLine($"HP: {HP} / {HPMax}\n" +
                $"XP: {XP} / {XPMax}\n" +
                $"DAMAGE: {Damage}");
        }

        public virtual void PrintHeroInfo()
        {
            Console.WriteLine($"HERO: {Name}\n" +
                $"TYPE: {Type}\n" +
                $"LEVEL: {Level}\n" +
                $"HP: {HP}/{HPMax} \n" +
                $"XP: {XP}/{XPMax} \n" +
                $"DAMAGE: {Damage}");
        }
    }
}

