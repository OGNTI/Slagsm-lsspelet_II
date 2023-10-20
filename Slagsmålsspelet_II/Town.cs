public class Town
{
    List<Weapon> buyableWeapons = new();
    int[] WeaponsPrices = { 10, 23, 38, 59 };
    int[] buyableWeaponsPrices = { 0, 0, 0, 0 };
    List<Armour> buyableArmour = new();
    int[] ArmourPrices = { 15, 29, 47, 68 };
    int[] buyableArmourPrices = { 0, 0, 0, 0 };
    int priceRange = 5;
    int requiredStreak = 6;
    int baseWinnings = 40;
    int baseWinningsRange = 12;
    int baseInnCost = 10;
    int baseInnCostRange = 3;
    int currentEnemy;
    List<int> existingEnemies = new();
    Random generator = new Random();


    public void Inn(Player player, NameLists nameList, List<Fighter> fighters) //pass time, fully regen health with gold
    {
        int innCost = generator.Next(baseInnCost - baseInnCostRange, baseInnCost + baseInnCostRange + 1);
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
                buyableWeapons.Clear();
                buyableArmour.Clear();
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

    public void Street(Player player, NameLists nameList, List<Fighter> fighters) //pass time, regen or lose health for free
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
        buyableWeapons.Clear();
        buyableArmour.Clear();

        if (!player.GetAlive())
        {
            Console.WriteLine("\nThe rats succeded in their attempt to get inside you, your body is now a five star rat hotel.");
        }
    }

    public void Shop(Player player, NameLists nameList, List<Fighter> fighters)
    {
        int streak = 0;
        foreach (Fighter f in fighters)
        {
            if (!f.GetAlive()) //how many fighters are dead
            {
                streak++;
            }
        }

        if (streak >= requiredStreak && player.weapon.quality != "Legendary")
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
                Console.WriteLine("\nWeapons:");
                for (int i = 0; i < player.weapon.qualityNames.Count; i++)
                {
                    if (buyableWeapons.Count < player.weapon.qualityNames.Count)
                    {
                        buyableWeapons.Add(new Weapon()); //create temporary weapon to showcase
                        buyableWeapons[i].SetName(nameList.GetWeaponTypeName(), i);
                    }
                    buyableWeaponsPrices[i] = generator.Next(WeaponsPrices[i] - priceRange, WeaponsPrices[i] + priceRange + 1);
                    Console.WriteLine($"{i + 1}: {buyableWeapons[i].name} - [{buyableWeaponsPrices[i]} gold]");
                }

                Console.WriteLine(" \nArmour:");
                for (int i = 0; i < player.weapon.qualityNames.Count; i++)
                {
                    if (buyableArmour.Count < player.weapon.qualityNames.Count)
                    {
                        buyableArmour.Add(new Armour()); //create temporary armour to showcase
                        buyableArmour[i].SetName(generator.Next(buyableArmour[i].types.Count), generator.Next(buyableArmour[i].materialNames.Count), i);
                    }
                    buyableArmourPrices[i] = generator.Next(ArmourPrices[i] - priceRange, ArmourPrices[i] + priceRange + 1);
                    Console.WriteLine($"{i + buyableWeapons.Count + 1}: {buyableArmour[i].name} - [{buyableArmourPrices[i]} gold]");
                }
                Console.WriteLine("\n[or \"Leave\"]");
                string userInput = Console.ReadLine().ToLower();
                int.TryParse(userInput, out int index);
                int wIndex = 0;
                int aIndex = 0;
                if (index <= buyableWeapons.Count) //make index for weapon
                {
                    wIndex = index;
                }
                else if (index <= buyableArmour.Count + buyableWeapons.Count) //make index for armour so not out of range when using the index with list
                {
                    aIndex = index - buyableArmourPrices.Length;
                }

                bool bought = false;
                if (wIndex != 0 || aIndex != 0)
                {
                    if (wIndex != 0)
                    {
                        if (player.gold >= buyableWeaponsPrices[wIndex - 1])
                        {
                            player.gold -= buyableWeaponsPrices[wIndex - 1];
                            bought = true;
                        }
                    }
                    else if (aIndex != 0)
                    {
                        if (player.gold >= buyableArmourPrices[aIndex - 1])
                        {
                            player.gold -= buyableArmourPrices[aIndex - 1];
                            bought = true;
                        }
                    }

                    if (bought && wIndex != 0)
                    {
                        string oldWeapon = player.weapon.name;
                        player.weapon.SetName(buyableWeapons[wIndex - 1].type, wIndex - 1);
                        buyableWeapons.Clear(); //clear after purchase to restock next time

                        Console.WriteLine($"You bought a {player.weapon.name}, sold your {oldWeapon} and left the Blacksmiths Shop.");

                        acceptedAnswer = true;
                    }
                    else if (bought && aIndex != 0)
                    {
                        int typePos = 0;
                        if (buyableArmour[aIndex - 1].type == buyableArmour[aIndex - 1].types[0])
                        {
                            typePos = 0;
                        }
                        else if (buyableArmour[aIndex - 1].type == buyableArmour[aIndex - 1].types[1])
                        {
                            typePos = 1;
                        }
                        else if (buyableArmour[aIndex - 1].type == buyableArmour[aIndex - 1].types[2])
                        {
                            typePos = 2;
                        }

                        string oldArmour = player.armours[typePos].name;
                        player.AddArmour(buyableArmour[aIndex - 1]);
                        buyableArmour.Clear(); //clear after purchase to restock next time
                        if (oldArmour == null)
                        {
                            Console.WriteLine($"You bought a {player.armours[typePos].name} and left the Blacksmiths Shop.");
                        }
                        else
                        {
                            Console.WriteLine($"You bought a {player.armours[typePos].name}, sold your {oldArmour} and left the Blacksmiths Shop.");
                        }

                        acceptedAnswer = true;
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough gold to buy that. \n ");
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
            }
        }
    }

    public void Arena(Player player, NameLists nameList, List<Fighter> fighters)
    {
        existingEnemies.Clear();
        bool fightersExist = false;
        for (int i = 0; i < fighters.Count; i++)
        {
            if (fighters[i].GetAlive() && fighters[i] is not Player)
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
            Console.Write($"Your opponent is {fighters[currentEnemy].name} who wields a {fighters[currentEnemy].weapon.name} and wears");
            if (fighters[currentEnemy].HasArmour())  //write correct grammar
            {
                for (int i = 0; i < fighters[currentEnemy].armours.Length; i++)
                {
                    if (fighters[currentEnemy].armours[i].exists)
                    {
                        if (i != 0) //as long as it is not he first armour being written
                        {
                            if (fighters[currentEnemy].armours[0].exists || fighters[currentEnemy].armours[1].exists)
                            {
                                int howMany = 0;
                                foreach (Armour a in fighters[currentEnemy].armours) //check how many armour pieces in total they are wearing 
                                {
                                    if (a.exists)
                                    {
                                        howMany++;
                                    }
                                }

                                if (howMany == 2) //if only wearing two, write "and" between them
                                {
                                    if (fighters[currentEnemy].armours[0].exists) //if doesn't matter which armour (out of the two last) the "and" is put before because 0 exists
                                    {
                                        Console.Write(" and");
                                    }
                                    else if (fighters[currentEnemy].armours[1].exists && i == 2) //if 1 exists and is 2
                                    {
                                        Console.Write(" and");
                                    }
                                }
                                else if (howMany == 3)
                                {
                                    if (i == 2)
                                    {
                                        Console.Write(" and");
                                    }
                                    else if (i == 1)
                                    {
                                        Console.Write(",");
                                    }
                                }
                            }
                        }

                        Console.Write($" {fighters[currentEnemy].armours[i].name}");
                    }
                }
            }
            else
            {
                Console.Write(" no armour");
            }
            Console.WriteLine("."); //end with .
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
                        fighters[i].SetArmourValues(); //make sure armour values are up to date
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
            Console.WriteLine("Light Attack, Heavy Attack or Block? [L/H/B]");
            string userAction = Console.ReadLine().ToLower();
            int enemyaction = generator.Next(3);
            Console.WriteLine("");

            if (userAction == "block" || userAction == "b")
            {
                player.Block();
            }
            if (enemyaction == 2)
            {
                fighters[currentEnemy].Block();
            }

            if (userAction == "light" || userAction == "l")
            {
                player.LightAttack(fighters[currentEnemy], nameList);
            }
            else if (userAction == "heavy" || userAction == "h")
            {
                player.HeavyAttack(fighters[currentEnemy], nameList);
            }
            if (enemyaction == 0)
            {
                fighters[currentEnemy].LightAttack(player, nameList);
            }
            else if (enemyaction == 1)
            {
                fighters[currentEnemy].HeavyAttack(player, nameList);
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
        int enemyWeaponQuality = generator.Next(fighters[currentEnemy].weapon.qualityNames.Count);
        fighters[currentEnemy].weapon.SetName(nameList.GetWeaponTypeName(), enemyWeaponQuality);
        int enemyArmourQuality = generator.Next(fighters[currentEnemy].weapon.qualityNames.Count);
        int enemyArmourMaterial = generator.Next(fighters[currentEnemy].armours[0].materialNames.Count);

        for (int i = 0; i < fighters[currentEnemy].armours.Length; i++)
        {
            int privilegeOfArmour = generator.Next(2);
            if (privilegeOfArmour == 0)
            {
                Armour newArmour = new();
                newArmour.SetName(i, enemyArmourMaterial, enemyArmourQuality);
                fighters[currentEnemy].AddArmour(newArmour);
            }
        }
    }
}