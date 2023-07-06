using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A class to trigger the csucessful ompletion of a level */
public class END_Trigger : MonoBehaviour
{
    public Game_Manager game_manager;           // a reference to a Game_Manager object
    private float complete_level_delay = 2f;

    void OnTriggerEnter()
    {
        game_manager.Complete_Level();
        Destroy(this.gameObject);
    }

}
