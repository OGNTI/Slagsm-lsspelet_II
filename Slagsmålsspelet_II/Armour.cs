public class Armour: Gear
{
    public List<string> types = new() {"Leggings", "Chestplate", "Helmet"};
    public bool exists = false;
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
        exists = true;

        if (quality == qualityNames[0])
        {
            if (type == types[0])
            {
                armourValue = 5;
            }
            else if (type == types[1])
            {
                armourValue = 7;
            }
            else if (type == types[2])
            {
                armourValue = 3;
            }
        }
        else if (quality == qualityNames[1])
        {
            if (type == types[0])
            {
                armourValue = 12;
            }
            else if (type == types[1])
            {
                armourValue = 15;
            }
            else if (type == types[2])
            {
                armourValue = 9;
            }
        }
        else if (quality == qualityNames[2])
        {
            if (type == types[0])
            {
                armourValue = 18;
            }
            else if (type == types[1])
            {
                armourValue = 22;
            }
            else if (type == types[2])
            {
                armourValue = 15;
            }
        }
        else if (quality == qualityNames[3])
        {
            if (type == types[0])
            {
                armourValue = 28;
            }
            else if (type == types[1])
            {
                armourValue = 35;
            }
            else if (type == types[2])
            {
                armourValue = 23;
            }
        }

        if (material == materialNames[0])
        {
            dodgeValue = 9;
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