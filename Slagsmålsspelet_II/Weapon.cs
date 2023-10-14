public class Weapon
{
    public string name;
    public string quality;
    public List<string> qualities = new List<string>() {"rubbish", "decent", "fine", "exceptional"};
    int baseDamage;
    int baseDamageRange;
    int damage;

    Random generator = new();


    public int GetDamage()
    {
        if (quality == "rubbish")
        {
            baseDamage = 6;
            baseDamageRange = 4;
        }
        else if (quality == "decent")
        {
            baseDamage = 10;
            baseDamageRange = 3;
        }
        else if (quality == "fine")
        {
            baseDamage = 17;
            baseDamageRange = 3;
        }
        else if (quality == "exceptional")
        {
            baseDamage = 24;
            baseDamageRange = 6;
        }
        damage = generator.Next(baseDamage - baseDamageRange, baseDamage + baseDamageRange + 1);

        return damage;
    }
}
