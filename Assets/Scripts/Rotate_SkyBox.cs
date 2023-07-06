using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_SkyBox : MonoBehaviour
{
    public float rotation_speed = 1.3f;

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotation_speed);
    }
}
