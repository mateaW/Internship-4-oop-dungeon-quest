using Dungeon_Crawler.Domain.Repositories.Heroes;

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
    }
}
