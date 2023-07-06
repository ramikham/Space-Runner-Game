// Refrences:
// [1] https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fade_Text_Effect : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float fadeInTime;
    public float fadeOutTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade_Text());
    }

    // A function to display text fading effect
    // Resources: [1]
    IEnumerator Fade_Text()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);

        yield return new WaitForSeconds(1f);

        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / fadeOutTime));
            text.fontMaterial.SetFloat("_Softness", Mathf.Lerp(1f, 0f, text.color.a));
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / fadeInTime));
            text.fontMaterial.SetFloat("_Softness", Mathf.Lerp(1f, 0f, text.color.a));
            
            yield return null;
        }
       
       


       
      //  Destroy(gameObject);
    }
}
