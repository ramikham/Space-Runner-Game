// References:
// [1] https://yunhan.li/unity/2017/12/19/math-wave.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Bounce : MonoBehaviour
{
    // Reference to the Player_Controller.cs Script
    // --------------------------------------------
    public GameObject player_ref;       // new
    private Player_Controller Player_Controller_script;     // new

    // Reference to Heart_Counter_Controller.cs Script
    // -----------------------------------------------
    public GameObject heart_counter_text_ref;
    private Heart_Counter_Controller Heart_Counter_Controller_script;

    private float Bounce_Speed = 1f; // 20 f is challenging
    private float Bounce_Height = 1f;
    private float Rotation_Speed = 90f;

    private float Start_Height;
    private float Time_Offset;

    public Transform Rocket_Transform;

    // Start is called before the first frame update
    void Start()
    {
        Player_Controller_script = player_ref.GetComponent<Player_Controller>();            // initialize ref to Player_Controller script
        Heart_Counter_Controller_script = heart_counter_text_ref.GetComponent<Heart_Counter_Controller>();

        Start_Height = transform.localPosition.y + 4;
        Time_Offset = Random.value * Mathf.PI * 2;
    }

    // Update is called once per frame
    // References: [1]
    void Update()
    {
        // animat
        float finalheight = Start_Height + Mathf.Sin(Time.time * Bounce_Speed + Time_Offset) * Bounce_Height - 4;
        var position = transform.localPosition;
        position.y = finalheight;
        transform.localPosition = position;

        // rotate
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += Rotation_Speed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }

    /*
    void OnCollisionEnter(Collision collision_info)
    {
        //collision_info.rigidbody.maxDepenetrationVelocity = 1;
        //collision_info.rigidbody.velocity = Vector3.zero ;
       // collision_info.rigidbody.mass = 0;
       // collision_info.rigidbody.isKinematic = false;
        Debug.Log("Collision with heart");
      //  Rocket_Transform.GetComponent<MeshCollider>().enabled = false;
       // Destroy(this.gameObject);
    }*/


    void OnTriggerEnter(Collider other)
    {
        Player_Controller_script.player_lives++;
        Debug.Log(Player_Controller_script.player_lives);
        Debug.Log("Collision with heart");

        Heart_Counter_Controller_script.Write_Heart_Counter(Player_Controller_script.player_lives - 1);     // reflect the update in the text (note the - 1 because player_lives is init to 1 in my script)
            
        Destroy(this.gameObject);
    }
}
