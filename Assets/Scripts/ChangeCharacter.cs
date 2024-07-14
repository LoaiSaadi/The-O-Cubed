using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public GameObject cube; // Reference to the cube
    public GameObject sphere; // Reference to the sphere
    public float timeToChange = 30.0f; // Time in seconds to change the character

    void Start()
    {
        // Ensure the sphere is inactive at the start
        sphere.SetActive(false);
        // Start the coroutine to change the character
        StartCoroutine(ChangeCharacterAfterTime(timeToChange));
    }

    IEnumerator ChangeCharacterAfterTime(float time)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(time);

        // Deactivate the cube and activate the sphere
        cube.SetActive(false);
        sphere.SetActive(true);

        // Optional: transfer the position and rotation of the cube to the sphere
        sphere.transform.position = cube.transform.position;
        sphere.transform.rotation = cube.transform.rotation;
    }
}