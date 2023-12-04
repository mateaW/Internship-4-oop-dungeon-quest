using Dungeon_Crawler.Domain.Repositories.Heroes;

bool game = true;

while (game)
{
    Console.Clear();
    Console.WriteLine("---- DUNGEON CRAWLER ----");
    Console.WriteLine("1 - IGRAJ\n" +
        "2 - IZAĐI IZ IGRE");

    var _ = int.TryParse(Console.ReadLine(), out int choice);

    if (choice == 1)
    {
        StartGame();
    }
    else if (choice == 2)
    {
        game = false;
    }
    else
    {
        Console.WriteLine("Pogrešan unos.");
        continue;
    }
}

static void StartGame()
{
    var hero = ChooseHero();
    Console.Clear();

    if (hero == 1)
    {
        Console.WriteLine("Odabrali ste GLADIATORA.");
        var name = PickHeroName();
        Gladiator gladiator = new(name);
        Console.Clear();
        Console.WriteLine("Početne informacije o vašem heroju: ");
        gladiator.PrintInfo();
        bool play = AskToPlay();
        if (play)
        {
            PlayWithGladiator(gladiator);
        }
        else
        {
            return;
        }
    }
    else if (hero == 2)
    {
        Console.WriteLine("Odabrali ste ENCHANTERA");
        var name = PickHeroName();
        Enchanter enchanter = new(name);
        Console.Clear();
        Console.WriteLine("Trenutne informacije o vašem heroju: ");
        enchanter.PrintInfo();
        bool play = AskToPlay();
        if (play)
        {
            PlayWithEnchanter(enchanter);
        }
        else
        {
            return;
        }
        
    }
    else if(hero == 3)
    {
        Console.WriteLine("Odabrali ste MARKSMANA");
        var name = PickHeroName();
        Marksman marksman = new(name);
        Console.Clear();
        Console.WriteLine("Trenutne informacije o vašem heroju: ");
        marksman.PrintInfo();
        bool play = AskToPlay();
        if (play)
        {
            PlayWithMarksman(marksman);
        }
        else
        {
            return;
        }
    }
    else
    {
        Hero heroToPlay = MakeNewHero();
        bool play = AskToPlay();
        if (play)
        {
            PlayWithNewHero(heroToPlay);
        }
        else
        {
            return;
        }
        
    }
}

static bool AskToPlay()
{
    Console.WriteLine();
    while(true)
    {
        Console.WriteLine("Započni igru (da/ne)?");
        var answer = Console.ReadLine()!;
        if (answer.ToLower() == "da")
        {
            return true;
        }
        else if (answer.ToLower() == "ne")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Pogrešan unos.");
        }
    }
}
static int ChooseHero()
{
    Console.Clear();
    Console.WriteLine("---- ODABERI SVOG HEROJA ----");
    Console.WriteLine();
    Console.WriteLine("1 - GLADIATOR\n" +
        "2 - ENCHANTER\n" +
        "3 - MARKSMAN\n" +
        "4 - NOVI HEROJ");

    int[] choices = { 1, 2, 3, 4 };
    while (true)
    {
        var _ = int.TryParse(Console.ReadLine(), out int choice);
        if (choices.Contains(choice))
        {
            return choice;
        }
        else
        {
            Console.WriteLine("Pogrešan unos.");
        }
    }
}

static void PlayWithGladiator(Gladiator gladiator)
{


}
static void PlayWithEnchanter(Enchanter enchanter)
{

}

static void PlayWithMarksman(Marksman marksman)
{

}

static Hero MakeNewHero()
{
    Console.Clear();
    Console.WriteLine("Odabrali ste napraviti vlastitog heroja.");
    var name = PickHeroName();
    Hero newHero = new(name);
    while (true)
    {
        Console.WriteLine("Unesite vrijednost za HP: ");
        var input = Console.ReadLine();
        if(int.TryParse(input, out int hp))
        {
            newHero.HP = hp;
            newHero.HPMax = hp;
            break;
        }
        else
        {
            Console.WriteLine("Pogrešan unos.");
        }
    }
    while (true)
    {
        Console.WriteLine("Unesite vrijednost za DAMAGE: ");
        var input = Console.ReadLine();
        if (int.TryParse(input, out int damage))
        {
            newHero.Damage = damage;
            break;
        }
        else
        {
            Console.WriteLine("Pogrešan unos.");
        }
    }
    Console.Clear();
    Console.WriteLine("Trenutne informacije o vašem heroju: ");
    newHero.PrintInfo();
    return newHero;
}

static void PlayWithNewHero(Hero hero)
{

}

static string PickHeroName()
{
    string name;
    while (true)
    {
        Console.WriteLine("Unesite ime svog heroja: ");
        name = Console.ReadLine()!;
        if (name == "")
        {
            Console.WriteLine("Ime ne smije biti prazno");
        }
        else
        {
            break;

        }
    }
    return name;
}