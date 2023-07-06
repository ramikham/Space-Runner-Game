using UnityEngine;

public class Random_Locator : MonoBehaviour
{
    // The range of possible x, y, and z positions for the objects
    public float xRange = 10f;
   // public float yRange = 10f;
    public float zRange = 10f;

    // An array to store the objects that need to be randomized
    public GameObject[] objects;

    void Start()
    {
        // Loop through all the objects in the array
        foreach (GameObject obj in objects)
        {
            // Generate random x, y, and z positions within the specified range
            float xPos = Random.Range(-xRange, xRange);
          //  float yPos = Random.Range(0, yRange);
            float zPos = Random.Range(800, zRange);

            // Set the object's position to the generated random position
            obj.transform.position = new Vector3(xPos, 1.170001f, zPos);
        }
    }
}
