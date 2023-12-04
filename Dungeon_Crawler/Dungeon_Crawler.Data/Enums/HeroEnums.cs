using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler.Data.Enums
{
    public enum HeroType
    {
        Gladiator,
        Enchanter,
        Marksman
    }

    public enum HeroHP
    {
        Gladiator = 100,
        Enchanter = 25,
        Marksman = 50
    }

    public enum HeroDamage
    {
        Gladiator = 25,
        Enchanter = 100,
        Marksman = 50
    }
}
