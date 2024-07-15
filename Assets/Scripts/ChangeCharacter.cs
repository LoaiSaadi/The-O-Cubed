using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    /*
        /// <summary>
        /// Change once after 10 seconds
        /// </summary>
        public GameObject cube; // Reference to the cube
        public GameObject sphere; // Reference to the sphere
        public float timeToChange = 5.0f; // Time in seconds to change the character

        void Start()
        {
            // Ensure the sphere is inactive at the start
            sphere.SetActive(false);
            // Start the coroutine to change the character
            StartCoroutine(ChangeCharacterFromCubeToSphere(timeToChange));


            // Call ChangeCharacterFromSphereToCube after timeToChange seconds
            StartCoroutine(DelayedSwitchToCube(timeToChange));
        }

        IEnumerator ChangeCharacterFromCubeToSphere(float time)
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

        IEnumerator DelayedSwitchToCube(float time)
        {
            // Wait for timeToChange seconds
            yield return new WaitForSeconds(time);

            // Call the coroutine to switch back to cube
            StartCoroutine(ChangeCharacterFromSphereToCube(timeToChange));
        }

        IEnumerator ChangeCharacterFromSphereToCube(float time)
        {
            // Wait for the specified time
            yield return new WaitForSeconds(time);

            // Deactivate the sphere and activate the cube
            sphere.SetActive(false);
            cube.SetActive(true);

            // Optional: transfer the position and rotation of the sphere to the cube
            cube.transform.position = sphere.transform.position;
            cube.transform.rotation = sphere.transform.rotation;
        }
    */




    /// <summary>
    /// Change every 10 repeatedly
    /// </summary>
    public GameObject cube; // Reference to the cube
    public GameObject sphere; // Reference to the sphere
    public float switchInterval = 10.0f; // Time in seconds between switches

    void Start()
    {
        // Ensure the cube is active and sphere is inactive at the start
        cube.SetActive(true);
        sphere.SetActive(false);

        // Start the coroutine to switch characters
        StartCoroutine(SwitchCharacters());
    }

    IEnumerator SwitchCharacters()
    {
        while (true)
        {
            // Wait for switchInterval seconds
            yield return new WaitForSeconds(switchInterval);

            // Toggle between cube and sphere
            if (cube.activeSelf)
            {
                // Switch from cube to sphere
                cube.SetActive(false);
                sphere.SetActive(true);

                // Optional: transfer the position and rotation of the cube to the sphere
                sphere.transform.position = cube.transform.position;
                sphere.transform.rotation = cube.transform.rotation;
            }
            else
            {
                // Switch from sphere to cube
                sphere.SetActive(false);
                cube.SetActive(true);

                // Optional: transfer the position and rotation of the sphere to the cube
                cube.transform.position = sphere.transform.position;
                cube.transform.rotation = sphere.transform.rotation;
            }
        }
    }
}