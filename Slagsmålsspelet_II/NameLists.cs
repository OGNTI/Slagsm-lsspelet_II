public class NameLists
{
    List<string> personNames = new() { "Bob", "Steve", "Greg", "Flavia", "Quintis", "Tiberius", "Bjornulf", "Glenn" };
    List<string> weaponTypeNames = new() { "Spatha", "Axe", "Spear", "Dagger", "Hammer", "Gladius", "Trident", "Javelin", "Crossbow", "Greatsword" };
    Random generator = new();


    public string GetPersonName() //random person name
    {
        int index = generator.Next(personNames.Count);
        string name = personNames[index];

        return name;
    }

    public string GetWeaponTypeName() //random weapon type
    {
        int index = generator.Next(weaponTypeNames.Count);
        string name = weaponTypeNames[index];

        return name;
    }
}
