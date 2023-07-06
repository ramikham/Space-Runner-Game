using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Heart_Counter_Controller : MonoBehaviour
{
    // Reference to TextUI (to edit text next to the heart)
    // ----------------------------------------------------
    private TextMeshProUGUI TextMeshPro_component;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshPro_component = GetComponent<TextMeshProUGUI>();          // initialize the TextMeshPro ref
    }

    public void Write_Heart_Counter(int hearts_counter)
    {
        TextMeshPro_component.text = hearts_counter.ToString();
    }
}
