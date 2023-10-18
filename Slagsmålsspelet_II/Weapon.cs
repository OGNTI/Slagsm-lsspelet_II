public class Weapon : Gear
{
    int baseDamage;
    int baseDamageRange;
    Random generator = new();


    public void SetName(string nameInput, int qualityIndex)
    {
        name = qualityNames[qualityIndex] + " " + nameInput;
        quality = qualityNames[qualityIndex];
    }

    public int GetDamage(NameLists nameList)
    {
        if (quality == qualityNames[0])
        {
            baseDamage = 8;
            baseDamageRange = 3;
        }
        else if (quality == qualityNames[1])
        {
            baseDamage = 13;
            baseDamageRange = 3;
        }
        else if (quality == qualityNames[2])
        {
            baseDamage = 18;
            baseDamageRange = 3;
        }
        else if (quality == qualityNames[3])
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
