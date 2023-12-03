namespace Dungeon_Crawler.Domain.Repositories.Monsters
{
    public class Goblin : Monster
    {
        public Goblin()
        {
            this.Type = "Goblin";
            this.HP = 150;
            this.HPMax = 150;
            this.XP = 100;
            this.Damage = 100;
        }
    }
}
