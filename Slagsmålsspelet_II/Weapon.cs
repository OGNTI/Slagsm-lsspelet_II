public class Weapon : Gear
{
    int baseDamage;
    int baseDamageRange;
    Random generator = new();


    public void SetName(string nameInput, int qualityIndex)
    {
        type = nameInput;
        if (qualityIndex >= qualityNames.Count)
        {
            quality = "Legendary";
        }
        else
        {
            quality = qualityNames[qualityIndex];
        }
        name = quality + " " + type;
        SetBaseStats();
    }

    public int GetStats()
    {
        return baseDamage;
    }

    public int GetDamage(NameLists nameList)
    {
        int damage = generator.Next(baseDamage - baseDamageRange, baseDamage + baseDamageRange + 1);

        return damage;
    }

    void SetBaseStats()
    {
        if (quality == qualityNames[0])
        {
            baseDamage = 8;
            baseDamageRange = 3;
        }
        else if (quality == qualityNames[1])
        {
            baseDamage = 12;
            baseDamageRange = 3;
        }
        else if (quality == qualityNames[2])
        {
            baseDamage = 17;
            baseDamageRange = 4;
        }
        else if (quality == qualityNames[3])
        {
            baseDamage = 23;
            baseDamageRange = 4;
        }
        else if (quality == "Legendary")
        {
            baseDamage = 50;
            baseDamageRange = 5;
        }
    }
}
