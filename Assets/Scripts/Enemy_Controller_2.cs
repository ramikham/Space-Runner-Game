// References:
// [1] https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller_2 : MonoBehaviour
{
    public Transform startPoint; // The starting point of the object's movement
    public Transform endPoint; // The end point of the object's movement
    public float speed = 0.05f; // The speed at which the object moves

    private float startTime; // The time at which the movement starts
    private float journeyLength; // The total distance the object needs to travel


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
    }

    // Update is called once per frame
    // Reference: [1]
    void Update()
    {
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / journeyLength;
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, fractionOfJourney);
    }
}
