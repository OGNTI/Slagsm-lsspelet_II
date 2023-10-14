NameList nameList = new();
bool singlePlayer = true;
List<Fighter> fighters = new();
Random generator = new Random();


bool acceptedAnswer = false;
while (!acceptedAnswer)
{
    Console.WriteLine("One player or Two players? [1/2]");
    string input = Console.ReadLine().ToLower();

    if (input == "1" || input == "one")
    {
        singlePlayer = true;
        acceptedAnswer = true;
    }
    else if (input == "2" || input == "two")
    {
        singlePlayer = false;
        acceptedAnswer = true;
    }
}

if (singlePlayer)
{
    Console.WriteLine("What is your fighters name?");
    Fighter player = new();
    player.Name(Console.ReadLine());
    fighters.Add(player);

    Fighter enemy1 = new();
    enemy1.Name(nameList.GetName());
    fighters.Add(enemy1);

    while (player.GetAlive() && enemy1.GetAlive())
    {
        Console.WriteLine();
        foreach (Fighter f in fighters)
        {
            f.PrintStats();
        }
        Console.WriteLine();

        Console.WriteLine("Attack or Block?\n ");
        string userInput = Console.ReadLine().ToLower();
        int enemyaction = generator.Next(2);

        if (userInput == "block" || userInput == "b")
        {
            player.Block();
        }
        if (enemyaction == 1)
        {
            enemy1.Block();
        }

        if (userInput == "attack" || userInput == "a")
        {
            player.Attack(enemy1);
        }
        if (enemyaction == 0)
        {
            enemy1.Attack(player);
        }

        if (player.blocking && enemy1.blocking)
        {
            Console.WriteLine($"{player.name} and {enemy1.name} both blocked.");
        }
    }
}
else if (!singlePlayer)
{
    Console.WriteLine("Player 1, What is your fighters name?");
    Fighter player1 = new();
    player1.Name(Console.ReadLine());
    fighters.Add(player1);

    Console.WriteLine("Player 2, What is your fighters name?");
    Fighter player2 = new();
    player2.Name(Console.ReadLine());
    fighters.Add(player2);

    while (player1.GetAlive() && player2.GetAlive())
    {
        Console.WriteLine();
        foreach (Fighter f in fighters)
        {
            f.PrintStats();
        }
        Console.WriteLine();

        Console.WriteLine("Player 1, Attack or Block?\n ");
        string player1Input = Console.ReadLine().ToLower();
        Console.Clear();

        Console.WriteLine("Player 2, Attack or Block?\n ");
        string player2Input = Console.ReadLine().ToLower();
        Console.Clear();

        if (player1Input == "block" || player1Input == "b")
        {
            player1.Block();
        }
        if (player2Input == "block" || player2Input == "b")
        {
            player2.Block();
        }

        if (player1Input == "attack" || player1Input == "a")
        {
            player1.Attack(player2);
        }
        if (player2Input == "attack" || player2Input == "a")
        {
            player2.Attack(player1);
        }

        if (player1.blocking && player2.blocking)
        {
            Console.WriteLine($"{player1.name} and {player2.name} both blocked.");
        }

        Console.ReadLine();
    }
}

Console.WriteLine("end lol, someone died");
Console.ReadLine();


