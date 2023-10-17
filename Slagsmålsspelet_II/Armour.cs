﻿public class Armour: Gear
{
    // public string name = "errorName";
    // public string quality;
    // public List<string> qualities = new() {"Rubbish", "Decent", "Fine", "Exceptional"};
    // public string material;
    // public List<string> materials = new() {"Leather", "Iron", "Steel"};
    public string type;
    public List<string> types = new() {"Leggings", "Chestplate", "Helmet"};
    int armourValue;

    public string GetName()
    {
        name = quality + " " + material + " " + type;

        return name;
    }

    public int GetArmourValue()
    {
        if (quality == qualityNames[0])
        {
            armourValue = 5;
        }
        else if (quality == qualityNames[1])
        {
            armourValue = 12;
        }
        else if (quality == qualityNames[3])
        {
            armourValue = 20;
        }else if (quality == qualityNames[4])
        {
            armourValue = 34;
        }

        return armourValue;
    }
}



// add light armour that increases dodge and heavy armour that just is strong
// Chestpiece, Leggings, Helmet