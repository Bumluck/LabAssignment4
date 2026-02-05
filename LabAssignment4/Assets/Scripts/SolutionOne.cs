using NUnit.Framework;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class SolutionOne : MonoBehaviour
{
    [Header("Inputs")]
    //Ask the user for these in the inspector
    public string characterName;
    public string charClass;
    public int level;
    public int constitution;
    int conMod;
    public string characterRace;
    public bool averageHP;

    //StoutTough Check
    public bool hasStout;
    public bool hasTough;

    [Header("Orc, Dwarf and Goliath HP bonuses")]
    //RaceCheck Hp bonuses
    public int dwarfBonus;
    public int orcBonus;
    public int goliathBonus;

    [Header("This is how much HP this character has")]
    //Output HP
    public float charHP;

    //Lists for classes and constitution modifiers
    public List<CharClass> classHitDie;
    public List<ConMod> conMods;

    //(Class hit die * level) + (conModifier * level) + 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (level < 1 || level > 20)
        {
            level = 1;
            Debug.Log("Current level is impossible, setting level to the default of 1");
        }
        if (constitution < 1 || constitution > 30)
        {
            constitution = 1;
            Debug.Log("That constitution is impossible, setting constitution to 1");
        }
        charHP = ClassHP();
        charHP += (float)ConHP();
        charHP += RaceCheck();
        charHP += FeatCheck();

    }

    float ClassHP()
    {
        float classHP;

        for (int i = 0; i < classHitDie.Count - 1; i++)
        {
            if (charClass.Equals(classHitDie[i].charClass, System.StringComparison.OrdinalIgnoreCase))
            {  
                if (averageHP)
                {
                    classHP = level * ((classHitDie[i].hitDie / 2) + 0.5f);
                    classHP = Mathf.Ceil(classHP);
                    return classHP;
                }
                else
                {
                    classHP = level * Random.Range(1, classHitDie[i].hitDie);
                    return classHP;
                }
            }
        }
        Debug.Log("Class not found! Setting class hp to the default of 1");
        return 1;
    }

    int ConHP()
    {
        int conHP;
        for (int i = 0; i < conMods.Count - 1; i++)
        {
            if (constitution >= conMods[i].rangeTop - 1 && constitution <= conMods[i].rangeTop)
            {
                conHP = conMods[i].conMod * level;
                return conHP;
            }
        }
        Debug.Log("Constitution error occurred, setting constitution HP to 1");
        return 1;
    }

    int RaceCheck()
    {
        int raceHP;
        if (characterRace.Equals("Dwarf", System.StringComparison.OrdinalIgnoreCase))
        {
            raceHP = level * dwarfBonus;
            return raceHP;
        }
        else if (characterRace.Equals("Goliath", System.StringComparison.OrdinalIgnoreCase))
        {
            raceHP = level * goliathBonus;
            return raceHP;
        }
        else if (characterRace.Equals("Orc", System.StringComparison.OrdinalIgnoreCase))
        {
            raceHP = level * orcBonus;
            return raceHP;
        }
            return 0;
    }

    int FeatCheck()
    {
        int featHP = 0;
        if (hasStout)
        {
            featHP = level * 1;
        }
        if (hasTough)
        {
            featHP += level * 2;
        }
        return featHP;
    }
}
