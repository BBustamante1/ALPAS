using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetCharacterDescription : MonoBehaviour
{
    private string charName;
    [SerializeField] private string charDescription;

    public void SetDescriptionValues()
    {
        charName = gameObject.name;
        CharDescPanel.GetInstance().ShowCharDescription(charName, charDescription);
    }
}
