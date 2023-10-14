public class Town
{
    List<string> buyableWeapons = new List<string>();
    List<int> buyableWeaponsPrices = new List<int>() { 16, 28, 40, 65 };
    Random generator = new Random();


    public void Inn(Fighter player)
    {
        int innCost = generator.Next(10 - 3, 10 + 3 + 1);
        Console.WriteLine($"\nYou wish to rest at the Inn to regain your health. \nInnkeeper tells you it will cost {innCost} gold for a night, \ndo you still wish to rest? [yes/no]");
        string userInput = Console.ReadLine().ToLower();
        if (userInput == "yes" || userInput == "y")
        {
            if (player.gold >= innCost)
            {
                player.currentHp = player.maxHp;
                Console.WriteLine("You bought a room at the Inn and spent the night to regain your health.");
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

    public void Shop(Fighter player, NameLists namelist)
    {
        Console.WriteLine("\nYou enter the Blacksmiths Shop and greet Hephaestus, he shows you his current selection of Weapons and Armour.");
        bool acceptedAnswer = false;
        while (!acceptedAnswer)
        {
            Console.WriteLine("What do you wish to buy?");
            for (int i = 0; i < 4; i++)
            {
                buyableWeaponsPrices[i] = generator.Next(buyableWeaponsPrices[i] - 5, buyableWeaponsPrices[i] + 5 + 1);
                buyableWeapons.Add(player.weapon.qualities[i] + " " + namelist.GetWeaponName() + $" - [{buyableWeaponsPrices[i]} gold]");
                Console.WriteLine($"{i + 1}: {buyableWeapons[i]}");
            }
            Console.WriteLine("[or \"Leave\"]");
            string userInput = Console.ReadLine().ToLower();
            int.TryParse(userInput, out int index);

            bool bought = false;
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
            else if (userInput == "leave")
            {
                Console.WriteLine("You left the Blacksmiths Shop.");
                acceptedAnswer = true;
            }
            else
            {
                Console.WriteLine("That was not an option.");
            }
            if (index == 1 || index == 2 || index == 3 || index == 4)
            {
                if (bought)
                {
                    player.weapon.name = buyableWeapons[index - 1];
                    player.weapon.quality = player.weapon.qualities[index - 1];
                    Console.WriteLine($"\nYou bought a {buyableWeapons[index - 1]} and left the Blacksmith Shop.");
                    acceptedAnswer = true;
                }
                else
                {
                    Console.WriteLine("You do not have enough gold to buy that. \n ");
                }
            }
        }
    }

    public void Arena(Fighter player, List<Fighter> fighters, NameLists namelist)
    {
        fighters.RemoveAll(f => !f.GetAlive());
        fighters.Add(new Fighter());
        int currentEnemy = fighters.Count - 1;
        fighters[currentEnemy].Name(namelist.GetPersonName());
        fighters[currentEnemy].weapon.quality = fighters[currentEnemy].weapon.qualities[1];

        while (player.GetAlive() && fighters[currentEnemy].GetAlive())
        {
            Console.WriteLine();
            foreach (Fighter f in fighters)
            {
                f.PrintStats();
            }
            Console.WriteLine();

            Console.WriteLine("Attack or Block?");
            string userInput = Console.ReadLine().ToLower();
            int enemyaction = generator.Next(2);
            Console.WriteLine("");

            if (userInput == "block" || userInput == "b")
            {
                player.Block();
            }
            if (enemyaction == 1)
            {
                fighters[currentEnemy].Block();
            }

            if (userInput == "attack" || userInput == "a")
            {
                player.Attack(fighters[currentEnemy]);
            }
            if (enemyaction == 0)
            {
                fighters[currentEnemy].Attack(player);
            }

            if (player.blocking && fighters[currentEnemy].blocking)
            {
                Console.WriteLine($"{player.name} and {fighters[currentEnemy].name} both blocked.");
            }

            Console.WriteLine("");
            if (!player.GetAlive())
            {
                Console.WriteLine($"{player.name} died");
            }
            else if (!fighters[currentEnemy].GetAlive())
            {
                Console.WriteLine($"{fighters[currentEnemy].name} died and {player.name} won 20 gold");
                player.gold += 20;
            }
        }
    }
}