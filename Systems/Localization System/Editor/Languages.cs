using System;

[Serializable]
public class Language
{
    private string _name;
    private string _code;

    public string Name { get; }
    public string Code { get; }

    public Language(string name, string code)
    {
        _name = name;
        _code = code;
    }
}
