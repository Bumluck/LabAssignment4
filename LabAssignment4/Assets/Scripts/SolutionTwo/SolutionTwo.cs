using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SolutionTwo : SolutionOne
{
    //  Inherit from Solution one so I do not have to rewrite a bunch of code
    //  whilst adding in additional variables and logic to let the user instantiate
    //  their character with the data they entered.

    #region VARIABLES

    [Header("Solution Two Items")]
    public bool instantiateCharacter;
    [SerializeField] GameObject charPrefab;
    Character spawnedCharacter;

    #endregion

    #region MONOBEHAVIOUR FUNCTIONS

    //  Override the Start method to add in character instantiation logic
    //  with the power of polymorphism

    //---------------------------//
    protected override void Start()
    //---------------------------//
    {
        base.Start();
        if (instantiateCharacter)
        {
            InstantiateCharacter();
        }
    }

    #endregion

    #region INSTANTIATE CHARACTER

    //------------------------------//
    public void InstantiateCharacter()
    //------------------------------//
    {
        //Create a new characterData class with our input values and our calculated HP
        CharacterData characterData = new CharacterData(charHP, charName, level, charClass, characterRace);

        //Instantiate a character, pass our CharacterData into the character, and tell the character to process that data
        spawnedCharacter = Instantiate(charPrefab).GetComponent<Character>();
        spawnedCharacter.characterData = characterData;
        spawnedCharacter.ProcessData();


        Debug.Log("Character has spawned and data should have been passed to them");
    }

    #endregion
}
