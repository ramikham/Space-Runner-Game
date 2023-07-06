using Unity.VisualScripting;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    // Reference to Player_Controller Script
    // -------------------------------------
    public Player_Controller controller;

    // Reference to Heart_Counter_Controller Script
    // --------------------------------------------
    public Heart_Counter_Controller heart_controller;

    // References to Audio
    // ------------------------
    public AudioSource collision_audiosound_source;

    // Reference to Transofrm
    // ----------------------
    public Transform player_transform;

    private Vector3 fixed_rotation;         // the initital rotation of the player's transform component

    // Final Level Logic
    // ---------------------------
    private int allowed_lives = 0;

    public void Start()
    {
        // Initialize rotation:
        fixed_rotation = controller.transform.eulerAngles;              // get the initital rotation of the player's transform component
    }

    

    /**
     * The function process the collision between our player 
     * and any collidable object.
     */
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "OBSTACLE")       // if we collide with an OBSTACLE
        {
            collision_audiosound_source.Play();
           
            if (controller.player_lives == 1)   // game over
            {
                controller.enabled = false;                                             // the player can no more be controlled
                Invoke("Game_Over_Behavior", 0.9f);
                FindObjectOfType<Game_Manager>().Game_Over();                           // search for the Game_Manager object and invoke the Game_Over() function
                collision.gameObject.GetComponent<Fracture>().FractureObject();         // invoke the fracturing effect
            
            } else
            {
                controller.player_rigid_body.freezeRotation = true;                     // avoids funny collision when player is not supposed to die 
                Destroy(collision.gameObject);                                          // since player collected heart(s), they still have live(s)
                controller.player_lives--;                                              // decrement the hearts the player has
                heart_controller.Write_Heart_Counter(controller.player_lives - 1);      // new
                controller.player_rigid_body.transform.eulerAngles = fixed_rotation;    // avoids funny rotation caused by collision by resetting the rotation of the player's transform component to its initial state
            }         
        }  

        if (collision.collider.tag == "ENEMY")
        {
            if (allowed_lives == 0)                                                     // game over in final level
            {
                Invoke("Game_Over_Behavior", 0.1f);
                FindObjectOfType<Game_Manager>().Game_Over();                           // search for the Game_Manager object and invoke the Game_Over() function
            } else
            {
                allowed_lives--;
            }
        }

        if (collision.collider.tag == "ANCIENT ROCKS"){
            Debug.Log("Entered");
            Invoke("Fix_Rotation", 1.5f);
        }
    }

    /*
     * To be called to control the animation sequence 
     * once the game is over.
     */ 
    void Game_Over_Behavior()
    {
        controller.player_animator.speed = 0f;
    }

    public void Fix_Rotation()
    {
        player_transform.eulerAngles = Vector3.zero;
    } 
}
