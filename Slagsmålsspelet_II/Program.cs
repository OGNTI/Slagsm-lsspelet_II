NameLists nameList = new();
Town town = new();
List<Fighter> fighters = new();
bool singlePlayer = true;
bool gaming;
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
    gaming = true;
    player.gold = generator.Next(100 + 1);

    while (gaming)
    {
        Console.Clear();
        Console.WriteLine($"You are in the Town, You have {player.gold} gold and {player.currentHp}/{player.maxHp} Hp. \nWhat do you wish to do? \nRest at the Inn [1/rest] \nVisit the Blacksmiths Shop [2/shop] \nFight in the Arena [3/fight] \n");
        string userInput = Console.ReadLine().ToLower();

        if (userInput == "1" || userInput == "rest")
        {
            town.Inn(player);
        }
        else if (userInput == "2" || userInput == "shop")
        {
            town.Shop(player, nameList);
        }
        else if (userInput == "3" || userInput == "fight")
        {
            town.Arena(player, fighters, nameList);
        }
        Console.ReadLine();

        if (!player.GetAlive())
        {
            gaming = false;
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