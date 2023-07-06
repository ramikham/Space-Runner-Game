
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Reference to player's position
    // -------------------------------
    public Transform player;

    // TextGUI Reference
    // -----------------
    public TextMeshProUGUI score_text;

    // Class Data Members
    // ------------------
    public string player_score;

    void Start()
    {
        player_score = 0f.ToString();
    }

    public bool rocket_bonus = false;

    // Update is called once per frame
    void Update()
    {
        if (rocket_bonus)
        {
            score_text.text = (player.position.z * 2f).ToString("0");
        }
        else
        {
            score_text.text = player.position.z.ToString("0");          // player.position.z = how many units we moved along the z-axis
            player_score = score_text.text;       
        }
    }
}
