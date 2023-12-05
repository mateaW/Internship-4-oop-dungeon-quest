using Dungeon_Crawler.Data.Enums;
using Dungeon_Crawler.Domain.Repositories.Monsters;

namespace Dungeon_Crawler.Domain.Repositories.Heroes
{
    public class Enchanter : Hero
    {
        public int Mana { get; set; }

        public int MaxMana { get; set; }

        public bool CanRevive { get; set; }

        public Enchanter(string Name) : base(Name)
        {
            Mana = 15;
            MaxMana = 15;
            this.Type = "Enchanter";
            this.HP = (int)HeroHP.Enchanter;
            this.HPMax = HP;
            this.Damage = (int)HeroDamage.Enchanter;
            CanRevive = true; // he can only revive once
        }

        public void EnchanterAttack(Monster monster)
        {

            while(true)
            {
                Console.WriteLine("Upišite m ako želite iskoristitit manu za obnovu života," +
                        "a upišite p ako zelite napasti.\n");
                var input = Console.ReadLine()!;
                if(input.ToLower() == "m")
                {
                    ExchangeManaForHP(Mana);
                    break;
                }
                else if(input.ToLower() == "p")
                {
                    if (Mana > 0)
                    {
                        monster.HP -= Damage;
                        GetExperience(monster.XP);
                        Mana--;
                    }
                    else
                    {
                        Console.WriteLine("Nemate mane, ne možete napasti, ali ona će se obnoviti.");
                        RenewMana();
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos.");
                    continue;
                }
            }
            Console.WriteLine();
            PrintHeroInfo();
            Console.WriteLine();
            monster.PrintMonsterInfo();

        }

        public void ExchangeManaForHP(int manaToExchange)
        {
            if (Mana >= manaToExchange)
            {
                this.HP += manaToExchange;
                Console.WriteLine($"{Name} je iskoristio {manaToExchange} mane da bi dobio dodatne hp.");
                Mana -= manaToExchange;
                this.PrintHeroInfo();
            }
            else
            {
                Console.WriteLine("Nemate dovoljno mane za obnavljanje hp-a.");
            }
        }

        public void RenewMana()
        {
            if (Mana <= 0) 
            {
                Mana = MaxMana;
            }
        }

        public void Revive()
        {
            if (CanRevive)
            {
                HP = HPMax;
                Mana = MaxMana;
            }
            else
            {
                Console.WriteLine("Već ste jednom iskoristili mogućnost oživljavanja.");
            }
            CanRevive = false;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            Mana++;
        }

        public override void PrintHeroInfo()
        {
            base.PrintHeroInfo();
            Console.WriteLine($"MANA: {Mana} / {MaxMana}\n" +
                $"MOGUĆNOST OŽIVLJAVANJA: {CanRevive}");
        }
    }
}
