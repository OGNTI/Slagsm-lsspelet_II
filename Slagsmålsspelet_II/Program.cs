NameLists nameList = new();
Town town = new();
List<Fighter> fighters = new();
bool singlePlayer = true;
bool gaming;
Random generator = new Random();


bool acceptedAnswer = false;
while (!acceptedAnswer)
{
    Console.WriteLine("One player or Two players? [1/2] \n(Singleplayer a lot better than shitty Multiplayer)");
    string input = Console.ReadLine().ToLower().Trim();

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
    Console.WriteLine("What is your name?");
    Player player = new();
    player.Name(Console.ReadLine().Trim());
    player.SetStart();
    fighters.Add(player);
    town.AddEnemy(fighters, nameList);
    gaming = true;

    while (gaming)
    {
        Console.Clear();
        if (player.currentHp > player.maxHp)
        {
            player.currentHp = player.maxHp;
        }

        Console.WriteLine($"You are in the Town, You have {player.gold} gold and {player.currentHp}/{player.maxHp} Hp. \nWhat do you wish to do? \n \nRest at the Inn [1/rest] \nSleep on the street [2/sleep] \nVisit the Blacksmiths Shop [3/shop] \nFight in the Arena [4/fight] \nCheck your Backpack [5/inventory]");
        string userInput = Console.ReadLine().ToLower().Trim();

        if (userInput == "1" || userInput == "rest")
        {
            town.Inn(player, nameList, fighters);
            Console.ReadLine();
        }
        else if (userInput == "2" || userInput == "sleep")
        {
            town.Street(player, nameList, fighters);
            Console.ReadLine();
        }
        else if (userInput == "3" || userInput == "shop")
        {
            town.Shop(player, nameList, fighters);
            Console.ReadLine();
        }
        else if (userInput == "4" || userInput == "fight")
        {
            town.Arena(player, nameList, fighters);
            Console.ReadLine();
        }
        else if (userInput == "5" || userInput == "inventory")
        {
            player.OpenInventory();
            Console.ReadLine();
        }

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
            player1.LightAttack(player2, nameList);
        }
        if (player2Input == "attack" || player2Input == "a")
        {
            player2.LightAttack(player1, nameList);
        }

        if (player1.blocking && player2.blocking)
        {
            Console.WriteLine($"{player1.name} and {player2.name} both blocked.");
        }

        if (!player1.GetAlive())
        {
            Console.WriteLine($"{player1.name} was slain by {player2.name}.");
        }
        else if (!player2.GetAlive())
        {
            Console.WriteLine($"{player2.name} was slain by {player1.name}.");
        }
    }
}

Console.WriteLine("End.");
Console.ReadLine();