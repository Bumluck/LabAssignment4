using UnityEngine;

public class CharacterData
{
    public float health;
    public string charName;
    public int level;
    public string charClass;
    public string charRace;

    public CharacterData(float _health, string _name, int _level, string _class, string _race)
    {
        health = _health;
        charName = _name;
        level = _level;
        charClass = _class;
        charRace = _race;
    }
}
