using Dungeon_Crawler.Domain.Repositories.Heroes;

namespace Dungeon_Crawler.Domain.Repositories.Monsters
{
    public class Goblin : Monster
    {
        public Goblin() : base()
        {
            Random random = new();
            this.Type = "Goblin";
            this.HP = random.Next(1,11);
            this.XP = random.Next(1,11); 
            this.Damage = random.Next(1, 11);
        }

        public void GoblinAttack(Hero hero)
        {
            
        }
    }
}
