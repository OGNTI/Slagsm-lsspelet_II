public class Town
{
    List<Weapon> buyableWeapons = new();
    List<int> buyableWeaponsPrices = new() { 10, 23, 38, 59 };
    List<Armour> buyableArmour = new();
    List<int> buyableArmourPrices = new() { 15, 29, 47, 68 };
    int priceRange = 5;
    int requiredStreak = 6;
    int baseWinnings = 40;
    int baseWinningsRange = 13;
    int currentEnemy;
    List<int> existingEnemies = new();
    Random generator = new Random();


    public void Inn(Player player, NameLists nameList, List<Fighter> fighters)
    {
        int innCost = generator.Next(10 - 3, 10 + 3 + 1);
        Console.WriteLine($"You wish to rest at the Inn to regain your health. \nInnkeeper tells you it will cost {innCost} gold for a night, \ndo you still wish to rest? [yes/no]");
        string userInput = Console.ReadLine().ToLower();
        if (userInput == "yes" || userInput == "y")
        {
            if (player.gold >= innCost)
            {
                player.gold -= innCost;
                player.currentHp = player.maxHp;
                Console.WriteLine("You bought a room at the Inn and spent the night to regain your health.");
                AddEnemy(fighters, nameList);
            }
            else
            {
                Console.WriteLine("You can not afford a room so you leave the Inn.");
            }
        }
        else
        {
            Console.WriteLine("You changed your mind and left the Inn.");
        }
    }

    public void Street(Player player, NameLists nameList, List<Fighter> fighters)
    {

        int rats = generator.Next(2);
        int sleepRegen = 0;
        if (rats == 0)
        {
            sleepRegen = generator.Next(player.maxHp / 7);
            Console.WriteLine($"You spend the night sleeping on the street, ever' so often being \nawoken by a rat nibbling on your feet.");
        }
        else
        {
            sleepRegen -= generator.Next(player.maxHp / 6);
            Console.WriteLine($"You spend the night sleeping on the street in dread as it rains and \nthe local rats are determined to get inside you and bask in your inner warmth.");
        }
        player.currentHp += sleepRegen;
        AddEnemy(fighters, nameList);
    }

    public void Shop(Player player, NameLists nameList, List<Fighter> fighters)
    {
        int streak = 0;
        foreach (Fighter f in fighters)
        {
            if (!f.GetAlive())
            {
                streak++;
            }
        }

        int aTo = player.weapon.name.IndexOf(" ");
        string possibleLegendary = player.weapon.name.Substring(0, aTo);
        if (streak >= requiredStreak && possibleLegendary != "Legendary")
        {
            int legenWeaponPrice = 50;
            string legenWeaponName = nameList.GetWeaponTypeName();
            Console.WriteLine($"You enter the Blacksmiths Shop and greet Hephaestus, he takes you to the back of his shop where his forge lies. \nHe tells you he's been collecting the weapons of you fallen opponents and from them he has \nforged a Legendary {legenWeaponName} and he is willing to sell you it for the cheap price of {legenWeaponPrice} gold. \nDo you take his offer? [yes/no]");
            string userInput = Console.ReadLine().ToLower().Trim();

            if (userInput == "y" || userInput == "yes")
            {
                if (player.gold >= legenWeaponPrice)
                {
                    Console.WriteLine($"You bought a Legendary {legenWeaponName}, sold your {player.weapon.name} and left the Blacksmiths Shop.");
                    player.gold -= legenWeaponPrice;
                    player.weapon.SetName(legenWeaponName, 4);
                }
                else
                {
                    Console.WriteLine("You do not have enough gold to buy it.");
                }
            }
            else
            {
                Console.WriteLine($"You did not buy the Legendary {legenWeaponName}.");
            }
        }
        else
        {
            Console.WriteLine("You enter the Blacksmiths Shop and greet Hephaestus, he shows you his current selection of Weapons and Armour.");
            bool acceptedAnswer = false;
            while (!acceptedAnswer)
            {
                Console.WriteLine("What do you wish to buy?");
                Console.WriteLine(" \nWeapons:");
                for (int i = 0; i < player.weapon.qualityNames.Count; i++)
                {
                    if (buyableWeapons.Count < player.weapon.qualityNames.Count)
                    {
                        buyableWeapons.Add(new Weapon());
                        buyableWeapons[i].SetName(nameList.GetWeaponTypeName(), i);
                    }
                    buyableWeaponsPrices[i] = generator.Next(buyableWeaponsPrices[i] - priceRange, buyableWeaponsPrices[i] + priceRange + 1);
                    Console.WriteLine($"{i + 1}: {buyableWeapons[i].name} - [{buyableWeaponsPrices[i]} gold]");
                }

                Console.WriteLine(" \nArmour:");
                for (int i = 0; i < player.weapon.qualityNames.Count; i++)
                {
                    if (buyableArmour.Count < player.weapon.qualityNames.Count)
                    {
                        buyableArmour.Add(new Armour());
                        buyableArmour[i].SetName(generator.Next(buyableArmour[i].types.Count), generator.Next(buyableArmour[i].materialNames.Count), i);
                    }
                    buyableArmourPrices[i] = generator.Next(buyableArmourPrices[i] - priceRange, buyableArmourPrices[i] + priceRange + 1);
                    Console.WriteLine($"{i + buyableWeapons.Count + 1}: {buyableArmour[i].name} - [{buyableArmourPrices[i]} gold]");
                }
                Console.WriteLine(" \n[or \"Leave\"]");
                string userInput = Console.ReadLine().ToLower();
                int.TryParse(userInput, out int index);

                bool bought = false;

                //Weapons
                if (index == 1)
                {
                    if (player.gold >= buyableWeaponsPrices[index - 1])
                    {
                        player.gold -= buyableWeaponsPrices[index - 1];
                        bought = true;
                    }
                }
                else if (index == 2)
                {
                    if (player.gold >= buyableWeaponsPrices[index - 1])
                    {
                        player.gold -= buyableWeaponsPrices[index - 1];
                        bought = true;
                    }
                }
                else if (index == 3)
                {
                    if (player.gold >= buyableWeaponsPrices[index - 1])
                    {
                        player.gold -= buyableWeaponsPrices[index - 1];
                        bought = true;
                    }
                }
                else if (index == 4)
                {
                    if (player.gold >= buyableWeaponsPrices[index - 1])
                    {
                        player.gold -= buyableWeaponsPrices[index - 1];
                        bought = true;
                    }
                }

                //Armour
                else if (index == 5)
                {
                    if (player.gold >= buyableArmourPrices[index - 1])
                    {
                        player.gold -= buyableArmourPrices[index - 1];
                        bought = true;
                    }
                }
                else if (index == 6)
                {
                    if (player.gold >= buyableArmourPrices[index - 1])
                    {
                        player.gold -= buyableArmourPrices[index - 1];
                        bought = true;
                    }
                }
                else if (index == 7)
                {
                    if (player.gold >= buyableArmourPrices[index - 1])
                    {
                        player.gold -= buyableArmourPrices[index - 1];
                        bought = true;
                    }
                }
                else if (index == 8)
                {
                    if (player.gold >= buyableArmourPrices[index - 1])
                    {
                        player.gold -= buyableArmourPrices[index - 1];
                        bought = true;
                    }
                }

                else if (userInput == "leave")
                {
                    Console.WriteLine("You left the Blacksmiths Shop.");
                    acceptedAnswer = true;
                }
                else
                {
                    Console.WriteLine("That was not an option.");
                }

                if (index >= 1 && index <= 8)
                {
                    if (bought && index <= 4)
                    {
                        string oldWeapon = player.weapon.name;
                        player.weapon.SetName(buyableWeapons[index - 1].type, index - 1);
                        buyableWeapons.Clear();

                        Console.WriteLine($"You bought a {player.weapon.name}, sold your {oldWeapon} and left the Blacksmiths Shop.");

                        acceptedAnswer = true;
                    }
                    else if (bought && index >= 4)
                    {
                        string type = buyableArmour[index-1].type;
                        

                        // string oldWeapon = player.weapon.name;
                        // player.weapon.SetName(buyableWeapons[index - 1].type, index - 1);
                        // buyableWeapons.Clear();

                        // Console.WriteLine($"You bought a {player.weapon.name}, sold your {oldWeapon} and left the Blacksmiths Shop.");

                        // acceptedAnswer = true;
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough gold to buy that. \n ");
                    }
                }
            }
        }
    }

    public void Arena(Player player, NameLists nameList, List<Fighter> fighters)
    {
        // fighters.RemoveAll(f => !f.GetAlive());
        existingEnemies.Clear();
        bool fightersExist = false;
        for (int i = 0; i < fighters.Count; i++)
        {
            if (fighters[i].GetAlive() && fighters[i] is Fighter)
            {
                fightersExist = true;
                existingEnemies.Add(i);
            }
        }

        Console.WriteLine($"You head towards the Arena. You walk past the homeless people and go through the \ngates of the Arena and you greet Gnaeus Cornelius Lentulus Vatia.");
        bool fight = false;
        bool acceptedAnswer = false;

        if (!fightersExist)
        {
            Console.WriteLine("He tells you that there arn't any available opponents to fight and that you should come back tomorrow.");
            acceptedAnswer = true;
        }
        else
        {
            int index = generator.Next(existingEnemies.Count);
            currentEnemy = existingEnemies[index];
            Console.WriteLine($"Your opponent is {fighters[currentEnemy].name} who wields a {fighters[currentEnemy].weapon.name}.");
        }

        while (!acceptedAnswer)
        {
            Console.WriteLine("Do you wish to fight? [yes/no]");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "yes" || userInput == "y")
            {
                Console.WriteLine("You accept the fight and head out to the fighting pit.");
                fight = true;
                acceptedAnswer = true;

                for (int i = 0; i < fighters.Count; i++)
                {
                    if (i == currentEnemy || fighters[i] is Player)
                    {
                        fighters[i].PrintStats();
                    }
                }
                Console.WriteLine("");
            }
            else if (userInput == "no" || userInput == "n")
            {
                Console.WriteLine("You changed your mind and went back to the Town.");
                fight = false;
                acceptedAnswer = true;
            }
        }

        while (player.GetAlive() && fighters[currentEnemy].GetAlive() && fight)
        {
            Console.WriteLine("Attack or Block?");
            string userAction = Console.ReadLine().ToLower();
            int enemyaction = generator.Next(2);
            Console.WriteLine("");

            if (userAction == "block" || userAction == "b")
            {
                player.Block();
            }
            if (enemyaction == 1)
            {
                fighters[currentEnemy].Block();
            }

            if (userAction == "attack" || userAction == "a")
            {
                player.Attack(fighters[currentEnemy], nameList);
            }
            if (enemyaction == 0)
            {
                fighters[currentEnemy].Attack(player, nameList);
            }

            if (player.blocking && fighters[currentEnemy].blocking)
            {
                Console.WriteLine($"{player.name} and {fighters[currentEnemy].name} both blocked.");
            }

            Console.ReadLine();

            Console.Clear();
            for (int i = 0; i < fighters.Count; i++)
            {
                if (i == currentEnemy || fighters[i] is Player)
                {
                    fighters[i].PrintStats();
                }
            }
            Console.WriteLine();

            if (!player.GetAlive())
            {
                Console.WriteLine($"{player.name} was slain by {fighters[currentEnemy].name}. All your gold was tossed to the homeless people outside the Arenas gates \nand your body was thrown in the firepit where all fallen fighters end up.");
            }
            else if (!fighters[currentEnemy].GetAlive())
            {
                int winnings = generator.Next(baseWinnings - baseWinningsRange, baseWinnings + baseWinningsRange + 1);
                Console.WriteLine($"{fighters[currentEnemy].name} was slain by {player.name}. \nYou won {winnings} gold.");
                player.gold += winnings;
            }
        }
    }

    public void AddEnemy(List<Fighter> fighters, NameLists nameList)
    {
        fighters.Add(new Fighter());
        currentEnemy = fighters.Count - 1;
        fighters[currentEnemy].Name(nameList.GetPersonName());
        int enemyQuality = generator.Next(4);
        fighters[currentEnemy].weapon.SetName(nameList.GetWeaponTypeName(), enemyQuality);
    }
}