// Refrences:
// [1] -	https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rocket_Bounce : MonoBehaviour
{
    // Reference to score text
    // -----------------------
    public TextMeshProUGUI score_text;

    // Reference to Score.cs script
    // ----------------------------
    public GameObject Score_Panel_Ref;
    private Score Score_script;


    private float Bounce_Speed = 8f;
    private float Bounce_Height = 0.05f;
    private float Rotation_Speed = 90f;

    private float Start_Height;
    private float Time_Offset;

    public Transform Rocket_Transform;

    // Start is called before the first frame update
    void Start()
    {
        //  Score_script = 
        //Player_Controller_script = player_ref.GetComponent<Player_Controller>();

        Score_script = Score_Panel_Ref.GetComponent<Score>();

        Start_Height = transform.localPosition.y;
        Time_Offset = Random.value * Mathf.PI * 2;
    }

    // Update is called once per frame
    // Reference: [1]
    void Update()
    {
        // animate
        float finalheight = Start_Height + Mathf.Sin(Time.time * Bounce_Speed + Time_Offset) * Bounce_Height;
        var position = transform.localPosition;
        position.y = finalheight;
        transform.localPosition = position;

        // rotate
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += Rotation_Speed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }

    void OnTriggerEnter(Collider other)
    {
        //score_text.outlineColor
        score_text.color = Color.green;
        Debug.Log("Collision with rocket");
        Destroy(this.gameObject);
        //    Score_ref.rocket_bonus = true;
        //Score_ref.rocket_bonus = true;
        Score_script.rocket_bonus = true;
    }
}
