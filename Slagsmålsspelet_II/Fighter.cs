using System.Runtime.CompilerServices;

public class Fighter
{
    public string name = "Errorson";
    public int maxHp = 100;
    public int currentHp = 100;
    public Weapon weapon = new();
    public Armour[] armours = { new Armour(), new Armour(), new Armour() }; //can only have 3 Armours, Legs Chest Head
    public int totalArmour;
    public int totalDodge;
    public bool blocking = false;
    public int noArmourDodge = 10;
    bool alive;
    bool hasArmour;
    Random generator = new Random();


    public void Name(string nameInput) //Name fighter, can be userInput or not
    {
        if (nameInput == "") 
        {
            bool acceptedAnswer = false;
            while (!acceptedAnswer)
            {
                Console.WriteLine("A name cannot be blank. \nTry again.");
                nameInput = Console.ReadLine().Trim();

                if (nameInput != "")
                {
                    acceptedAnswer = true;
                }
            }
        }
        name = nameInput.ToLower();
        if (name.Length >= 2) //if string has enough characters for command below
        {
            name = char.ToUpper(name[0]) + name.Substring(1); //Capitalize first letter then add rest of string
        }
        alive = true;
    }

    public void LightAttack(Fighter target, NameLists nameList) //Light attack, regular damage, blocked does no damage, regular dodge chance
    {
        if (target.blocking)
        {
            Console.WriteLine($"{target.name} blocked {name}s attack.");
        }
        else
        {
            int miss = generator.Next(3);
            int dodge = generator.Next(90);
            if (dodge <= target.totalDodge - 1)
            {
                Console.WriteLine($"{name} tried to light attack but {target.name} dodged the attack.");
            }
            else if (miss == 0)
            {
                Console.WriteLine($"{name} tried to light attack {target.name} but missed.");
            }
            else
            {
                int damage = 0;
                int damageBA = weapon.GetDamage(nameList); //damage Before Armour
                if (target.HasArmour())
                {
                    float damageReduction = target.totalArmour / 100;
                    float damageAA = damageBA;
                    damageAA -= damageBA * damageReduction; //damage After Armour
                    damage = (int)damageAA;
                }
                else
                {
                    damage = (int)damageBA;
                }
                target.currentHp -= damage;
                Console.WriteLine($"{name} light attacked {target.name}. [DMG: {damage}]");
            }
        }
    }

    public void HeavyAttack(Fighter target, NameLists nameList) // Heavy attack, double damage, blocked does regular damage, twice as easy to dodge, easier to miss
    {
        int damage = 0;
        int damageBA = weapon.GetDamage(nameList); //damage Before Armour
        int miss = generator.Next(4);
        int dodge = generator.Next(90);

        if (!target.blocking && dodge <= target.totalDodge * 2 - 1)
        {
            Console.WriteLine($"{name} tried to heavy attack but {target.name} dodged the attack.");
        }
        else if (!target.blocking && miss == 0)
        {
            Console.WriteLine($"{name} tried to heavy attack {target.name} but missed.");
        }
        else
        {
                
            if (target.HasArmour())
            {
                float damageReduction = target.totalArmour / 100;
                float damageAA = damageBA;
                damageAA -= damageBA * damageReduction; //damage After Armour
                damage = (int)damageAA;
            }
            else
            {
                damage = (int)damageBA;
            }

            if (target.blocking)
            {
                target.currentHp -= damage;
                Console.WriteLine($"{target.name} tried to block {name}s heavy attack. [DMG: {damage}]");
            }
            else 
            {
                target.currentHp -= damage * 2;
                Console.WriteLine($"{name} heavy attacked {target.name}. [DMG: {damage * 2}]");
            }
        }
    }

    public void Block()
    {
        blocking = true;
    }

    public void PrintStats()
    {
        blocking = false;

        if (currentHp < 0)
        {
            currentHp = 0;
        }

        Console.WriteLine($"{name}: {currentHp}/{maxHp}");
    }

    public bool GetAlive()
    {
        if (currentHp <= 0)
        {
            alive = false;
        }

        return alive;
    }

    public void AddArmour(Armour newArmour) //find new armours type and replace that slot with new
    {
        if (newArmour.type == newArmour.types[0])
        {
            armours[0] = newArmour;
        }
        else if (newArmour.type == newArmour.types[1])
        {
            armours[1] = newArmour;
        }
        else if (newArmour.type == newArmour.types[2])
        {
            armours[2] = newArmour;
        }
    }

    public bool HasArmour()
    {
        foreach (Armour a in armours)
        {
            if (a.exists)
            {
                hasArmour = true;
            }
        }

        return hasArmour;
    }

    public void SetArmourValues()
    {
        totalArmour = 0;
        totalDodge = 0;
        foreach (Armour a in armours)
        {
            if (a.name == null)
            {
                totalArmour += 0;
                totalDodge += noArmourDodge;
            }
            else
            {
                totalArmour += a.armourValue;
                totalDodge += a.dodgeValue;
            }
        }
    }
}