using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Typing_Effect : MonoBehaviour
{
    // Reference to TextUI
    // -------------------------------------------
    private TextMeshProUGUI TextMeshPro_component;

    // How fast should the text by typed?
    // ----------------------------------
    public float typingSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshPro_component = GetComponent<TextMeshProUGUI>();          // initialize the TextMeshPro ref
        StartCoroutine(Type_Text(TextMeshPro_component.text));           // Invoke Type_Text() via a croutine
    }

    IEnumerator Type_Text(string inputText)
    {
        TextMeshPro_component.text = "";

        foreach (char c in inputText)
        {
            TextMeshPro_component.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
