bool game = true;
while (game)
{
    Console.WriteLine("---- DUNGEON CRAWLER ----");

    Console.WriteLine("1 - IGRAJ\n" +
        "2 - IZAĐI IZ IGRE");

    var _ = int.TryParse(Console.ReadLine(), out int choice);

    if (choice == 1)
    {
        StartGame();
        break;
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

    if (hero == 1)
    {
        FightWithGladiator();
    }
    else if (hero == 2)
    {
        FightWithEnchanter();
    }
    else if(hero == 3)
    {
        FightWithMarksman();
    }
    else
    {
        MakeNewHero();
    }
}

static int ChooseHero()
{
    Console.Clear();
    Console.WriteLine("---- ODABERI SVOG HEROJA ----");

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

static void FightWithGladiator()
{

}
static void FightWithEnchanter()
{

}

static void FightWithMarksman()
{

}

static void MakeNewHero()
{

}

