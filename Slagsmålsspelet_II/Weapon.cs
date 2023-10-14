public class Weapon
{
    public string name;
    int baseDamage = 15;
    int baseDamageRange = 4;
    int damage;

    Random generator = new();


    public int GetDamage()
    {
        damage = generator.Next(baseDamage - baseDamageRange, baseDamage + baseDamageRange + 1);

        return damage;
    }
}
