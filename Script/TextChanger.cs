using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
    public int value;
    public TMP_Text valueText;

    public void AddValue (int addition)
    {
        value += addition;

        UpdateText();
    }

    private void UpdateText()
    {
        valueText.text = value.ToString();
    }
}
