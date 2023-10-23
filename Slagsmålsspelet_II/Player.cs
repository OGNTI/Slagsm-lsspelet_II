public class Player : Fighter
{
    public int gold;
    int requiredXP = 5;
    int currentXP;
    Random generator = new Random();


    public void SetStart()
    {
        weapon.SetName("Dagger", 0);
        armours[0].SetName(0, 0, 0);
        gold = generator.Next(1000 + 1);
    }

    public void OpenInventory()
    {
        Console.WriteLine("\nYou own:");
        Console.WriteLine($"{weapon.name} [{weapon.GetStats()} base damage]");
        foreach (Armour a in armours)
        {
            if (a.exists)
            {
                Console.WriteLine($"{a.name} [{a.armourValue} armour, {a.dodgeValue} dodge]");
            }
        }
    }

    public void GainXP(int xpAmount)
    {
        currentXP += xpAmount;
        if (currentXP >= requiredXP)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        currentXP -= requiredXP;
        level++;
        requiredXP += level * 2;
        maxHp += 5;
        strength++;
        Console.WriteLine($"You are now level {level}.");
    }
}
