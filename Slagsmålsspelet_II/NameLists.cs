public class NameLists
{
    List<string> personNames = new List<string>() {"Bob", "Steve", "Greg", "Flavia", "Quintis", "Tiberius", "Bjornulf", "Glenn"};
    List<string> weaponNames = new List<string>() {"Spatha", "Axe", "Spear", "Dagger", "Hammer", "Gladius", "Trident", "Javelin", "Crossbow", "Greatsword"};
    Random generator = new();

    public string GetPersonName()
    {   
        int index = generator.Next(personNames.Count);
        string name = personNames[index];

        return name;
    }

    public string GetWeaponName()
    {
        int index = generator.Next(weaponNames.Count);
        string name = weaponNames[index];

        return name;
    }
}
