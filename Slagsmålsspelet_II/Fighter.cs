public class Fighter
{
    public string name = "Errorson";
    public int gold;
    public int maxHp = 100;
    public int currentHp = 100;
    public Weapon weapon = new();
    public bool blocking = false;
    bool alive;

    public void Name(string nameInput)
    {
        name = nameInput.ToLower();
        if (name.Length >= 2) //if string has enough characters for command below
        {
            name = char.ToUpper(name[0]) + name.Substring(1); //Capitalize first letter then add rest of string
        }
        alive = true;
    }

    public void Attack(Fighter target)
    {
        if (target.blocking)
        {
            Console.WriteLine($"{target.name} blocked {name}s attack.");
        }
        else
        {
            int damage = weapon.GetDamage();
            target.currentHp -= damage;
            Console.WriteLine($"{name} attacked {target.name}. [DMG: {damage}]");
        }
    }

    public void Block()
    {
        blocking = true;
    }

    public void PrintStats()
    {
        blocking = false;
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
}

