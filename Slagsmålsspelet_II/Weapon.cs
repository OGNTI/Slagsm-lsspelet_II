public class Weapon: Gear
{
    // public string name = "Dagger";
    // public string quality = "Rubbish";
    int baseDamage;
    int baseDamageRange;
    Random generator = new();

    public void GetName(Fighter fighter, string input, int qualityIndex)
    {
        int bTo = input.IndexOf(" -");

        fighter.weapon.name = input.Substring(0, bTo);
        fighter.weapon.quality = fighter.weapon.qualityNames[qualityIndex];
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
