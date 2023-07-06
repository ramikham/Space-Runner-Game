/*
 * References:
 *              - Animation scripting: https://www.youtube.com/watch?v=s7EIp-OqVyk
 */
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    // RigidBody Reference
    // -------------------
    public Rigidbody player_rigid_body;            // a reference for a RigidBody. This variable will hold a reference to the player's rigidbody.
   
    // Animation variables
    // -------------------
    public Animator player_animator;               // a referene to the player's Animator component 
    int jump_hash = Animator.StringToHash("Jump");
    int run_state_hash = Animator.StringToHash("Base Layer.Run");

    // Reference to score text
    // -----------------------
    public TextMeshProUGUI score_text;

    // Velocity Variables
    // ------------------
    public float forward_force = 1000f;
    public float sideways_force = 500f;
    public float jump_force = 200f;

    // Collision Responses Variables
    // -----------------------------
    private bool player_on_ground = true;               // player starts on the ground
    public float forward_force_penalty = 10000f;        // a speed penalty applied to the player once it passes over a trap
    public float forward_force_score_boost = 50f;         // was 5000f
    public int player_lives = 1;                       // # of lives the player has

    // References to Audio
    // ------------------------
    public AudioSource rocket_collision_audiosound_source;
    public AudioSource heart_collision_audiosound_source;
    public AudioSource rune_collision_audiosound_source;

    // Reference to END obstacle
    // -------------------------
    bool END_flag = false;

    // Reference to ENEMYs
    // -------------------
    int enemy_hit = 0;

    public void Start()
    {
        player_animator = GetComponent<Animator>();
  
    }

    void FixedUpdate()
    {
       // Debug.Log(END_flag);
        player_rigid_body.AddForce(0,0, forward_force * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("1_Main Menu");
        }
       
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            // Add a force to the right direction:
            player_rigid_body.AddForce(sideways_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            // Add a force to the left:
            player_rigid_body.AddForce(-sideways_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

      //  Debug.Log("Player on ground? " + player_on_ground);
        if (Input.GetKey(KeyCode.Space) && player_on_ground)
        {
            Debug.Log("Entered");

            player_rigid_body.AddForce(0f, jump_force * Time.deltaTime, 0f, ForceMode.Impulse);
            player_animator.SetTrigger("JUMP");             // // if the player jumps, then enter the JUMP animation
            player_on_ground = false;
        }

        player_animator.SetTrigger("RUN");
        
        if (player_rigid_body.position.y < -1 && END_flag == false)      // if the players falls from the edge of the ground
        {
            FindObjectOfType<Game_Manager>().Game_Over();               // then call Game_Over
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            player_on_ground = true;
        }

        /*
        if (collision.gameObject.CompareTag("TRAP"))
        {           
            forward_force += forward_force_penalty;
            score_text.color = Color.red;
            score_text.fontStyle = FontStyles.Bold;
        }*/

        if (collision.gameObject.CompareTag("ENEMY"))
        {
            Debug.Log(++enemy_hit);
        }
        /*
        if (collision.gameObject.CompareTag("Enemy 1"))
        {
            Debug.Log("Rune 1 attained through oncollision");
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ROCKET"))
        {
            Debug.Log("Before: " + forward_force);
            forward_force += forward_force_score_boost;
            Debug.Log("After: " + forward_force);
            score_text.color = Color.green;
            rocket_collision_audiosound_source.Play();
        }

        if (other.gameObject.CompareTag("HEART"))
        {
            heart_collision_audiosound_source.Play();
        }

        if (other.gameObject.CompareTag("TRAP"))
        {
            forward_force += forward_force_penalty;
            score_text.color = Color.red;
            score_text.fontStyle = FontStyles.Bold;
        }

        if (other.gameObject.name == "END")
        {
            END_flag = true;
        }

        // If the first kind of runes is triggered
        if (other.gameObject.CompareTag("RUNE 1") || other.gameObject.CompareTag("RUNE 2"))
        {
            Debug.Log("Rune 1 attained through trigger");
            Destroy(other.gameObject);
            rune_collision_audiosound_source.Play();
        }

    }

}
