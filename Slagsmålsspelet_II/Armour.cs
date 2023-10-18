public class Armour: Gear
{
    public string type;
    public List<string> types = new() {"Leggings", "Chestplate", "Helmet"};
    int armourValue;
    int dodgeValue;

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

    public int GetArmourDodge()
    {
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


        return dodgeValue;
    }
}



// add light armour that increases dodge and heavy armour that just is strong
// Chestpiece, Leggings, Helmet