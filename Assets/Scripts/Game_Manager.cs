using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Manager : MonoBehaviour
{
    // Reference to the Player_Controller.cs script
    // --------------------------------------------
    public GameObject player_ref;
    private Player_Controller Player_Controller_script;

    // Game Over?
    // ----------
    bool Game_Over_Flag = false;

    // Delay Restart() invokation
    // --------------------------
    private float Restart_Delay = 2.5f;      // was 1.5 but made it 10 for debugging 

    // Refrences to UIs
    // -------------------------------------


    public GameObject complete_level_UI;            // reference to the COMPLETE_LEVEL panel
    public GameObject game_over_UI;                 // reference to the GameOverPanel

    public void Start()
    {
        Player_Controller_script = player_ref.GetComponent<Player_Controller>();
    }

    // LEVEL COMPLETION FUNCTIONS
    // --------------------------------------------------

    // Function to be invoked when a level is completed
    public void Complete_Level()
    {
        Invoke("Show_Complete_Level_Panel", 1.0f);
    }

    // Function to be invoked by Complete_Level
    public void Show_Complete_Level_Panel()
    {
        complete_level_UI.SetActive(true);
    }
    // --------------------------------------------------

    // GAME OVER FUNCTIONS
    // --------------------------------------------------

    // Fuction to be invoked when the player triggers a losing condition
    public void Game_Over()
    {
        if (Game_Over_Flag == false && Player_Controller_script.player_lives == 1)
        {
            Game_Over_Flag = true;
            Invoke("Show_Game_Over_Panel", 0.5f);
            Debug.Log("GAME OVER!");
            Invoke("Restart", Restart_Delay);
        }
    }

    public void Show_Game_Over_Panel()
    {
        game_over_UI.SetActive(true);
    }

    // Function to be invoked when a restart command is issued
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
