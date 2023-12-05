using Dungeon_Crawler.Data.Enums;
using Dungeon_Crawler.Domain.Repositories.Heroes;
using Dungeon_Crawler.Domain.Repositories.Monsters;

MainMenu();

static void MainMenu()
{
    bool game = true;
    while (game)
    {
        Console.Clear();
        StartingText();

        var _ = int.TryParse(Console.ReadLine(), out int choice);

        if (choice == 1)
        {
            StartGame();
        }
        else if (choice == 2)
        {
            game = Exit();
        }
        else
        {
            Console.WriteLine("Pogrešan unos. Pokušajte ponovo.");
            Thread.Sleep(1000);
            continue;

        }
    }
}
static bool Exit()
{
    Console.Clear();
    Console.WriteLine("Izlaz iz igre ...");
    Thread.Sleep(1000);
    return false;
}

static void StartingText()
{
    Console.WriteLine("---- DOBRODOŠLI U DUNGEON CRAWLER ----");
    Console.WriteLine();
    Console.WriteLine("1 - IGRAJ\n" +
        "2 - IZAĐI IZ IGRE\n");
}

static void StartGame()
{
    var hero = ChooseHero();
    Console.Clear();

    if (hero == 1)
    {
        Console.WriteLine("Odabrali ste GLADIATORA.\n");
        var name = PickHeroName();
        Gladiator gladiator = new(name);
        Console.Clear();
        Console.WriteLine("Početne informacije o vašem heroju:\n");
        gladiator.PrintHeroInfo();
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
        Console.WriteLine("Odabrali ste ENCHANTERA.\n");
        var name = PickHeroName();
        Enchanter enchanter = new(name);
        Console.Clear();
        Console.WriteLine("Trenutne informacije o vašem heroju:\n");
        enchanter.PrintHeroInfo();
        bool play = AskToPlay();
        if (play)
        {
            PlayWithEnchanter(enchanter); //
        }
        else
        {
            return;
        }
    }
    else if(hero == 3)
    {
        Console.WriteLine("Odabrali ste MARKSMANA.\n");
        var name = PickHeroName();
        Marksman marksman = new(name);
        Console.Clear();
        Console.WriteLine("Trenutne informacije o vašem heroju:\n");
        marksman.PrintHeroInfo();
        bool play = AskToPlay();
        if (play)
        {
            PlayWithMarksman(marksman); //
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
            PlayWithNewHero(heroToPlay); //
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
        "4 - NOVI HEROJ\n");

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
    Monster monster = new();
    List<MonsterType> monsters = monster.MonsterGenerator(10);
    int wins = 0;
    for (int i = 1; i < monsters.Count; i++) 
    {
        Console.Clear();
        Console.WriteLine($"Za sada imate {wins} pobjeda.");
        Console.WriteLine($"{i}. protivnik je: {monsters[i]}.\n");

        if (monsters[i].ToString() == "Goblin")
        {
            Goblin monsterToPlay = new();
            while (true)
            {
                int gladiatorAction = ChooseAction(); 
                int monsterAction = MonsterAction(); 

                string winner = ChooseWinner(gladiatorAction, monsterAction); 

                Console.WriteLine(winner);

                if (winner == "Nitko nije pobijedio.")
                {
                    Console.WriteLine("Igra se ponovo ista runda.\n");
                    continue; 
                }

                else if (winner == "Pobijedili ste.")
                {
                    gladiator.GladiatorAttack(monsterToPlay); 
                }

                else if (winner == "Čudovište je pobijedilo.")
                {
                    monsterToPlay.GoblinAttack(gladiator); 
                }

                if (gladiator.HP <= 0)
                {
                    Console.WriteLine("Izgubili ste. Nemate više života.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    AfterLosing();
                }
                else if (monsterToPlay.HP <= 0)
                {
                    wins += 1;
                    Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    break;          
                }
                else
                {
                    continue;
                }
            }
        }
        else if(monsters[i].ToString() == "Brute")
        {
            Brute monsterToPlay = new();
            while (true)
            {
                int gladiatorAction = ChooseAction(); 
                int monsterAction = MonsterAction(); 

                string winner = ChooseWinner(gladiatorAction, monsterAction); 

                Console.WriteLine(winner);

                if (winner == "Nitko nije pobijedio.")
                {
                    Console.WriteLine("Igra se ponovo ista runda.\n");
                    continue; 
                }

                else if (winner == "Pobijedili ste.")
                {
                    gladiator.GladiatorAttack(monsterToPlay);
                }

                else if (winner == "Čudovište je pobijedilo.")
                {
                    monsterToPlay.BruteAttack(gladiator); 
                }

                if (gladiator.HP <= 0)
                {
                    Console.WriteLine("Izgubili ste. Nemate više života.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    AfterLosing(); 
                }
                else if (monsterToPlay.HP <= 0)
                {
                    wins += 1;
                    Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        else
        {
            Witch monsterToPlay = new();
            while (true)
            {
                int gladiatorAction = ChooseAction();
                int monsterAction = MonsterAction(); 

                string winner = ChooseWinner(gladiatorAction, monsterAction); 

                Console.WriteLine(winner);

                if (winner == "Nitko nije pobijedio.")
                {
                    Console.WriteLine("Igra se ponovo ista runda.\n");
                    continue; 
                }

                else if (winner == "Pobijedili ste.")
                {
                    gladiator.GladiatorAttack(monsterToPlay); 
                }

                else if (winner == "Čudovište je pobijedilo.")
                {
                    monsterToPlay.WitchAttack(gladiator); 
                }
                if (gladiator.HP <= 0)
                {
                    Console.WriteLine("Izgubili ste. Nemate više života.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    AfterLosing(); 
                }
                else if (monsterToPlay.HP <= 0)
                {
                    wins += 1;
                    Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
    Console.Clear();
    Console.WriteLine("Čestitamo. Pobijedili ste svih 10 čudovišta.\n");
    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
    Console.ReadKey();
    MainMenu();
}

static void AfterLosing()
{
    bool game = true;
    while (game)
    {
        ContinueText();

        var _ = int.TryParse(Console.ReadLine(), out int choice);

        if (choice == 1)
        {
            StartGame();
        }
        else if (choice == 2)
        {
            Exit();
        }
        else
        {
            Console.WriteLine("Pogrešan unos. Pokušajte ponovo.");
            Thread.Sleep(1000);
            continue;
        }
    }
}
static void ContinueText()
{
    Console.Clear();
    Console.WriteLine("---- IZGUBILI STE U IGRI ----\n");
    Console.WriteLine("1 - IGRAJ PONOVO\n" +
        "2 - IZAĐI IZ IGRE\n");
}

static int ChooseAction()
{
    Console.WriteLine("Odaberite svoj potez: ");
    Console.WriteLine("1 - DIREKTAN NAPAD\n" +
        "2 - NAPAD S BOKA\n" +
        "3 - PROTUNAPAD\n");
    int[] choices = { 1, 2, 3 };
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

static int MonsterAction()
{
    Random random = new();
    int monsterMove = random.Next(1, 4);
    if(monsterMove == 1)
    {
        Console.WriteLine("Čudovište je odabralo 1 - Direktan napad.");
    }
    else if (monsterMove == 2)
    {
        Console.WriteLine("Čudovište je odabralo 2 - Napad s boka.");
    }
    else
    {
        Console.WriteLine("Čudovište je odabralo 3 - Protunapad.");
    }
    return monsterMove;
}

static string  ChooseWinner(int heroAction, int monsterAction)
{
    string winner = "";
    if (heroAction == 1)
    {
        if (monsterAction == 1) 
        {
            winner = "Nitko nije pobijedio.";
        }
        else if(monsterAction == 2)
        {
            winner = "Pobijedili ste.";
        }
        else if(monsterAction == 3)
        {
            winner = "Čudovište je pobijedilo.";
        }
    }
    else if (heroAction == 2)
    {
        if (monsterAction == 1) 
        {
            winner = "Čudovište je pobijedilo.";
        }
        else if(monsterAction == 2)
        {
            winner = "Nitko nije pobijedio.";
        }
        else if (monsterAction == 3)
        {
            winner = "Pobijedili ste.";
        }
    }
    else
    {
        if (monsterAction == 1)
        {
            winner = "Pobijedili ste.";
        }
        else if (monsterAction == 2)
        {
            winner = "Čudovište je pobijedilo.";
        }
        else if (monsterAction == 3)
        {
            winner = "Nitko nije pobijedio.";
        }
    }
    return winner;
}

static void PlayWithEnchanter(Enchanter enchanter)
{
    Monster monster = new();
    List<MonsterType> monsters = monster.MonsterGenerator(10);
    int wins = 0;
    for (int i = 1; i < monsters.Count; i++)
    {
        Console.Clear();
        Console.WriteLine($"Za sada imate {wins} pobjeda.");
        Console.WriteLine($"{i}. protivnik je: {monsters[i]}.\n");

        if (monsters[i].ToString() == "Goblin")
        {
            Goblin monsterToPlay = new();
            while (true)
            {
                int enchanterAction = ChooseAction();
                int monsterAction = MonsterAction();

                string winner = ChooseWinner(enchanterAction, monsterAction);

                Console.WriteLine(winner);

                if (winner == "Nitko nije pobijedio.")
                {
                    Console.WriteLine("Igra se ponovo ista runda.\n");
                    continue;
                }

                else if (winner == "Pobijedili ste.")
                {
                    enchanter.EnchanterAttack(monsterToPlay);
                }

                else if (winner == "Čudovište je pobijedilo.")
                {
                    monsterToPlay.GoblinAttack(enchanter);
                }

                if (enchanter.HP <= 0)
                {
                    if(enchanter.CanRevive)
                    {
                        enchanter.Revive();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Izgubili ste. Nemate više života.");
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        AfterLosing();
                    }

                }
                else if (monsterToPlay.HP <= 0)
                {
                    wins += 1;
                    Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        else if (monsters[i].ToString() == "Brute")
        {
            Brute monsterToPlay = new();
            while (true)
            {
                int enchanterAction = ChooseAction();
                int monsterAction = MonsterAction();

                string winner = ChooseWinner(enchanterAction, monsterAction);

                Console.WriteLine(winner);

                if (winner == "Nitko nije pobijedio.")
                {
                    Console.WriteLine("Igra se ponovo ista runda.\n");
                    continue;
                }

                else if (winner == "Pobijedili ste.")
                {
                    enchanter.EnchanterAttack(monsterToPlay);
                }

                else if (winner == "Čudovište je pobijedilo.")
                {
                    monsterToPlay.BruteAttack(enchanter);
                }

                if (enchanter.HP <= 0)
                {
                    if (enchanter.CanRevive)
                    {
                        enchanter.Revive();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Izgubili ste. Nemate više života.");
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        AfterLosing();
                    }
                }
                else if (monsterToPlay.HP <= 0)
                {
                    wins += 1;
                    Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        else
        {
            Witch monsterToPlay = new();
            while (true)
            {
                int enchanterAction = ChooseAction();
                int monsterAction = MonsterAction();

                string winner = ChooseWinner(enchanterAction, monsterAction);

                Console.WriteLine(winner);

                if (winner == "Nitko nije pobijedio.")
                {
                    Console.WriteLine("Igra se ponovo ista runda.\n");
                    continue;
                }

                else if (winner == "Pobijedili ste.")
                {
                    enchanter.EnchanterAttack(monsterToPlay);
                }

                else if (winner == "Čudovište je pobijedilo.")
                {
                    monsterToPlay.WitchAttack(enchanter);
                }
                if (enchanter.HP <= 0)
                {
                    if (enchanter.CanRevive)
                    {
                        enchanter.Revive();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Izgubili ste. Nemate više života.");
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        AfterLosing();
                    }
                }
                else if (monsterToPlay.HP <= 0)
                {
                    wins += 1;
                    Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
    Console.Clear();
    Console.WriteLine("Čestitamo. Pobijedili ste svih 10 čudovišta.\n");
    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
    Console.ReadKey();
    MainMenu();
}

static void PlayWithMarksman(Marksman marksman)
{
    Monster monster = new();
    List<MonsterType> monsters = monster.MonsterGenerator(10);
    int wins = 0;
    for (int i = 1; i < monsters.Count; i++)
    {
        Console.Clear();
        Console.WriteLine($"Za sada imate {wins} pobjeda.");
        Console.WriteLine($"{i}. protivnik je: {monsters[i]}.\n");

        if (monsters[i].ToString() == "Goblin")
        {
            Goblin monsterToPlay = new();
            while (true)
            {
                int marksmanAction = ChooseAction();
                int monsterAction = MonsterAction();

                string winner = ChooseWinner(marksmanAction, monsterAction);

                Console.WriteLine(winner);

                if (winner == "Nitko nije pobijedio.")
                {
                    Console.WriteLine("Igra se ponovo ista runda.\n");
                    continue;
                }

                else if (winner == "Pobijedili ste.")
                {
                    if(marksman.PossibilityOfStunChance())
                    {
                        Console.WriteLine("Napadate uz pomoć svojstva Stun Chance, što znači da čudovište odmah gubi život.");
                        Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        marksman.MarksmanAttack(monsterToPlay);
                    }
                    
                }
                else if (winner == "Čudovište je pobijedilo.")
                {
                    monsterToPlay.GoblinAttack(marksman);
                }

                if (marksman.HP <= 0)
                {
                    Console.WriteLine("Izgubili ste. Nemate više života.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    AfterLosing();
                }
                else if (monsterToPlay.HP <= 0)
                {
                    wins += 1;
                    Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        else if (monsters[i].ToString() == "Brute")
        {
            Brute monsterToPlay = new();
            while (true)
            {
                int marksmanAction = ChooseAction();
                int monsterAction = MonsterAction();

                string winner = ChooseWinner(marksmanAction, monsterAction);

                Console.WriteLine(winner);

                if (winner == "Nitko nije pobijedio.")
                {
                    Console.WriteLine("Igra se ponovo ista runda.\n");
                    continue;
                }

                else if (winner == "Pobijedili ste.")
                {
                    if (marksman.PossibilityOfStunChance())
                    {
                        Console.WriteLine("Napadate uz pomoć svojstva Stun Chance, što znači da čudovište odmah gubi život.");
                        Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        marksman.MarksmanAttack(monsterToPlay);
                    }
                }

                else if (winner == "Čudovište je pobijedilo.")
                {
                    monsterToPlay.BruteAttack(marksman);
                }

                if (marksman.HP <= 0)
                {
                    Console.WriteLine("Izgubili ste. Nemate više života.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    AfterLosing();
                }
                else if (monsterToPlay.HP <= 0)
                {
                    wins += 1;
                    Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        else
        {
            Witch monsterToPlay = new();
            while (true)
            {
                int marksmanAction = ChooseAction();
                int monsterAction = MonsterAction();

                string winner = ChooseWinner(marksmanAction, monsterAction);

                Console.WriteLine(winner);

                if (winner == "Nitko nije pobijedio.")
                {
                    Console.WriteLine("Igra se ponovo ista runda.\n");
                    continue;
                }

                else if (winner == "Pobijedili ste.")
                {
                    if (marksman.PossibilityOfStunChance())
                    {
                        Console.WriteLine("Napadate uz pomoć svojstva Stun Chance, što znači da čudovište odmah gubi život.");
                        Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        marksman.MarksmanAttack(monsterToPlay);
                    }
                }

                else if (winner == "Čudovište je pobijedilo.")
                {
                    monsterToPlay.WitchAttack(marksman);
                }
                if (marksman.HP <= 0)
                {
                    Console.WriteLine("Izgubili ste. Nemate više života.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    AfterLosing();
                }
                else if (monsterToPlay.HP <= 0)
                {
                    wins += 1;
                    Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
    Console.Clear();
    Console.WriteLine("Čestitamo. Pobijedili ste svih 10 čudovišta.\n");
    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
    Console.ReadKey();
    MainMenu();
}

static Hero MakeNewHero()
{
    Console.Clear();
    Console.WriteLine("Odabrali ste napraviti vlastitog heroja.\n");
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
    newHero.PrintHeroInfo();
    return newHero;
}

static void PlayWithNewHero(Hero hero)
{
    Monster monster = new();
    List<MonsterType> monsters = monster.MonsterGenerator(10);
    int wins = 0;
    for (int i = 1; i < monsters.Count; i++) 
    {
        Console.Clear();
        Console.WriteLine($"Za sada imate {wins} pobjeda.");
        Console.WriteLine($"{i}. protivnik je: {monsters[i]}.\n");

        if (monsters[i].ToString() == "Goblin")
        {
            Goblin monsterToPlay = new();
            while (true)
            {
                int heroAction = ChooseAction(); 
                int monsterAction = MonsterAction(); 

                string winner = ChooseWinner(heroAction, monsterAction); 

                Console.WriteLine(winner);

                if (winner == "Nitko nije pobijedio.")
                {
                    Console.WriteLine("Igra se ponovo ista runda.\n");
                    continue; 
                }

                else if (winner == "Pobijedili ste.")
                {
                    hero.HeroAttack(monsterToPlay); 
                }

                else if (winner == "Čudovište je pobijedilo.")
                {
                    monsterToPlay.GoblinAttack(hero); 
                }

                if (hero.HP <= 0)
                {
                    Console.WriteLine("Izgubili ste. Nemate više života.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    AfterLosing();
                }
                else if (monsterToPlay.HP <= 0)
                {
                    wins += 1;
                    Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    break;          
                }
                else
                {
                    continue;
                }
            }
        }
        else if(monsters[i].ToString() == "Brute")
        {
            Brute monsterToPlay = new();
            while (true)
            {
                int heroAction = ChooseAction(); 
                int monsterAction = MonsterAction(); 

                string winner = ChooseWinner(heroAction, monsterAction); 

                Console.WriteLine(winner);

                if (winner == "Nitko nije pobijedio.")
                {
                    Console.WriteLine("Igra se ponovo ista runda.\n");
                    continue; 
                }

                else if (winner == "Pobijedili ste.")
                {
                    hero.HeroAttack(monsterToPlay);
                }

                else if (winner == "Čudovište je pobijedilo.")
                {
                    monsterToPlay.BruteAttack(hero); 
                }

                if (hero.HP <= 0)
                {
                    Console.WriteLine("Izgubili ste. Nemate više života.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    AfterLosing(); 
                }
                else if (monsterToPlay.HP <= 0)
                {
                    wins += 1;
                    Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        else
        {
            Witch monsterToPlay = new();
            while (true)
            {
                int heroAction = ChooseAction();
                int monsterAction = MonsterAction(); 

                string winner = ChooseWinner(heroAction, monsterAction); 

                Console.WriteLine(winner);

                if (winner == "Nitko nije pobijedio.")
                {
                    Console.WriteLine("Igra se ponovo ista runda.\n");
                    continue; 
                }

                else if (winner == "Pobijedili ste.")
                {
                    hero.HeroAttack(monsterToPlay); 
                }

                else if (winner == "Čudovište je pobijedilo.")
                {
                    monsterToPlay.WitchAttack(hero); 
                }
                if (hero.HP <= 0)
                {
                    Console.WriteLine("Izgubili ste. Nemate više života.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    AfterLosing(); 
                }
                else if (monsterToPlay.HP <= 0)
                {
                    wins += 1;
                    Console.WriteLine("PORAZILI STE ČUDOVIŠTE.");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
    Console.Clear();
    Console.WriteLine("Čestitamo. Pobijedili ste svih 10 čudovišta.\n");
    Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
    Console.ReadKey();
    MainMenu();
}

static string PickHeroName()
{
    string name;
    while (true)
    {
        Console.WriteLine("Unesite ime svog heroja:");
        name = Console.ReadLine()!;
        if (name == "")
        {
            Console.WriteLine("Ime ne smije biti prazno!!\n");
        }
        else
        {
            break;

        }
    }
    return name;
}