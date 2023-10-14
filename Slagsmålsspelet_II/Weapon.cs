public class Weapon
{
    public string name = "Dagger";
    public string quality = "Rubbish";
    public List<string> qualities = new() {"Rubbish", "Decent", "Fine", "Exceptional"};
    int baseDamage;
    int baseDamageRange;
    Random generator = new();


    public int GetDamage()
    {
        if (quality == qualities[0])
        {
            baseDamage = 6;
            baseDamageRange = 3;
        }
        else if (quality == qualities[1])
        {
            baseDamage = 10;
            baseDamageRange = 3;
        }
        else if (quality == qualities[2])
        {
            baseDamage = 17;
            baseDamageRange = 3;
        }
        else if (quality == qualities[3])
        {
            baseDamage = 24;
            baseDamageRange = 6;
        }
        else if (quality == "Legendary")
        {
            baseDamage = 50;
            baseDamageRange = 5;
        }
        int damage = generator.Next(baseDamage - baseDamageRange, baseDamage + baseDamageRange + 1);

        return damage;
    }
}
