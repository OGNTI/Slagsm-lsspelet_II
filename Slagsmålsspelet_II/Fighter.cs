using System.Runtime.CompilerServices;

public class Fighter
{
    public string name = "Errorson";
    public int maxHp = 100;
    public int currentHp = 100;
    public Weapon weapon = new();
    public Armour[] armours = {new Armour(), new Armour(), new Armour()};
    // public List<Armour> armours = new();
    public int totalArmour;
    public int totalDodge;
    public bool blocking = false;
    public int noArmourDodge = 30;
    bool alive;
    bool hasArmour;
    Random generator = new Random();
    

    public void Name(string nameInput)
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

    public void Attack(Fighter target, NameLists nameList)
    {
        if (target.blocking)
        {
            Console.WriteLine($"{target.name} blocked {name}s attack.");
        }
        else
        {
            int miss = generator.Next(4);
            // add dodge thing, totalDodge decides like 30 dodge = 1/3 chance
            if (miss == 0)
            {
                Console.WriteLine($"{name} attacked {target.name} but missed.");
            }
            else 
            {
                int damage = 0;
                int damageBA = weapon.GetDamage(nameList);
                if (target.HasArmour())
                {
                    float damageReduction = target.totalArmour/100;
                    float damageAA = damageBA - damageBA * damageReduction;
                    damage = (int)damageAA;
                }
                else
                {
                    damage = (int)damageBA;
                }
                target.currentHp -= damage;
                Console.WriteLine($"{name} attacked {target.name}. [DMG: {damage}]");
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

    public void AddArmour(Armour newArmour)
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
        if (HasArmour())
        {

            foreach (Armour a in armours)
            {
                totalArmour += a.armourValue;
                totalDodge += a.dodgeValue;
            }
        }
        else
        {
            totalArmour = 0;
            totalDodge = noArmourDodge;
        }
    }
}