public class Armour: Gear
{
    public List<string> types = new() {"Leggings", "Chestplate", "Helmet"};
    public int armourValue;
    public int dodgeValue;

    public string SetName(int typeIndex, int materialIndex, int qualityIndex)
    {
        type = types[typeIndex];
        material = materialNames[materialIndex];
        quality = qualityNames[qualityIndex];
        name = quality + " " + material + " " + type;
        SetBaseStats();

        return name;
    }

    void SetBaseStats()
    {
        if (quality == qualityNames[0])
        {
            armourValue = 5;
        }
        else if (quality == qualityNames[1])
        {
            armourValue = 12;
        }
        else if (quality == qualityNames[2])
        {
            armourValue = 20;
        }else if (quality == qualityNames[3])
        {
            armourValue = 34;
        }

        if (material == materialNames[0])
        {
            dodgeValue = 15;
        }
        else if (material == materialNames[1])
        {
            dodgeValue = -10;
        }
        else if (material == materialNames[2])
        {
            dodgeValue = -5;
        }
        else if (material == materialNames[3])
        {
            dodgeValue = -7;
        }
        else if (material == materialNames[4])
        {
            dodgeValue = 5;
        }
    }
}



// add light armour that increases dodge and heavy armour that just is strong
// Chestpiece, Leggings, Helmet