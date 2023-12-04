using Dungeon_Crawler.Data.Enums;

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

        public void UseManaForAttack()
        {
            if (Mana > 0)
            {
                Console.WriteLine($"{Name} koristi magičnu moć za napad.");
                Mana--;
            }
            else
            {
                Console.WriteLine($"{Name} nema dovoljno mane za napad. Mana će se obnoviti.");
                RenewMana();
            }
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
