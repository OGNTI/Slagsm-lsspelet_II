public class Player: Fighter
{
    public int gold;


    public void SetStart()
    {
        weapon.SetName("Dagger", 0);
    }

    public void OpenInventory()
    {
        Console.WriteLine($"\nYou own: \n{weapon.name}");
    }
}   
