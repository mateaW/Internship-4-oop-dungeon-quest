namespace Dungeon_Crawler.Domain.Repositories.Monsters
{
    public class Witch : Monster
    {
        public Witch()
        {
            this.Type = "Witch";
            this.HP = 350;
            this.HPMax = 350;
            this.XP = 100;
            this.Damage = 100;
        }

    }
}
