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
            CanRevive = true; 
        }

        public void EnchanterAttack(Monster monster)
        {
            while(true)
            {
                Console.WriteLine("Upišite 'OBNOVA' ako želite iskoristitit manu za obnovu života," +
                        "a upišite 'NAPAD' ako želite napasti.\n");
                var input = Console.ReadLine()!;
                if(input.ToLower() == "obnova")
                {
                    ExchangeManaForHP(Mana);
                    break;
                }
                else if(input.ToLower() == "napad")
                {
                    if (Mana > 0)
                    {
                        Console.WriteLine($"Napali ste čudovište i smanjili mu HP za {Damage},\n" +
                            $"dobili ste {monster.XP} XP-a. Mana se smanjila za 1.");
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
            this.PrintHeroInfo();
            Console.WriteLine();
            monster.PrintMonsterInfo();
        }

        public void ExchangeManaForHP(int manaToExchange)
        {
            if (Mana >= manaToExchange)
            {
                this.HP += manaToExchange;
                Mana -= manaToExchange;
                Console.WriteLine($"Iskoristili ste {manaToExchange} mane da bi dobili dodatne HP.\n" +
                    $"Sada imate {this.HP} HP-a.");
            }
            else
            {
                Console.WriteLine("Nemate dovoljno mane za obnavljanje HP-a.");
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

            Console.WriteLine("Iako ste izgubili protiv čudovišta, Enchanter ima mogućnost jednom oživjeti.\n" +
                "Možete nastaviti igru.");
            HP = HPMax;
            Mana = MaxMana;
            
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
