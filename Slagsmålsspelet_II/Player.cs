public class Player : Fighter
{
    public int gold;
    Random generator = new Random();


    public void SetStart()
    {
        weapon.SetName("Dagger", 0);
        armours[0].SetName(0, 0, 0);
        gold = generator.Next(10 + 1);
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
}
