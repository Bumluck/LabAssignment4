using UnityEngine;

public class Character : MonoBehaviour
{

    #region VARIABLES

    public CharacterData characterData;
    [Header("Character Information")]
    public float health;
    public string charName;
    public int level;
    public string charClass;
    public string charRace;

    #endregion

    public void ProcessData()
    {
        health = characterData.health;
        charName = characterData.charName;
        level = characterData.level;
        charClass = characterData.charClass;
        charRace = characterData.charRace;

        this.gameObject.name = charName;
        Debug.Log("Character has finished setting up");
    }


}
