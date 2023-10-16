public class Weapon
{
    public string name = "Dagger";
    public string quality = "Rubbish";
    int baseDamage;
    int baseDamageRange;
    Random generator = new();


    public int GetDamage(NameLists nameList)
    {
        if (quality == nameList.qualityNames[0])
        {
            baseDamage = 8;
            baseDamageRange = 3;
        }
        else if (quality == nameList.qualityNames[1])
        {
            baseDamage = 13;
            baseDamageRange = 3;
        }
        else if (quality == nameList.qualityNames[2])
        {
            baseDamage = 18;
            baseDamageRange = 3;
        }
        else if (quality == nameList.qualityNames[3])
        {
            baseDamage = 25;
            baseDamageRange = 7;
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
