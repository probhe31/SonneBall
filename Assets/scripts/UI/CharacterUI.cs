using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour {

    public Text nameCharacter;
    public Text price;
    public Image imageCharacter;
    public Text buttonText;


    public void SetCharacter(Character character, string textButton)
    {
        nameCharacter.text = character.characterName;
        price.text = "" + character.price;
        imageCharacter.sprite = character.sprite;
        this.buttonText.text = textButton;
    }

}
