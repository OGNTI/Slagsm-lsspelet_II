public class NameList
{
    public List<string> personNames = new List<string>() {"Bob", "Steve", "Greg", "Talion", "Aldon Hilter", "gay Neo"};
    Random generator = new();

    public string GetName()
    {   
        int index = generator.Next(personNames.Count);
        string name = personNames[index];

        return name;
    }
}
