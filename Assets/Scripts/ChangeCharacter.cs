/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{

    public GameObject cube; // Reference to the cube
    public GameObject sphere; // Reference to the sphere
    public float timeToChange = 5.0f; // Time in seconds to change the character

    void Start()
    {
        // Ensure the sphere is inactive at the start
        sphere.SetActive(false);

        /// Change once after 10 seconds
        // Start the coroutine to change the character
        StartCoroutine(ChangeCharacterFromCubeToSphere(timeToChange));
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

}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public GameObject cube; // Reference to the cube
    public GameObject sphere; // Reference to the sphere
    public GameObject octahedron; // Reference to the octahedron
    public float timeToChange = 5.0f; // Time in seconds to change the character

    void Start()
    {
        // Ensure the sphere and octahedron are inactive at the start
        sphere.SetActive(false);
        octahedron.SetActive(false);

        // Start the coroutine to change the character
        StartCoroutine(ChangeCharacterSequence());
    }

    IEnumerator ChangeCharacterSequence()
    {
        // Change from cube to sphere
        yield return ChangeCharacterFromTo(cube, sphere, timeToChange);

        // Change from sphere to octahedron
        yield return ChangeCharacterFromTo(sphere, octahedron, timeToChange);
    }

    IEnumerator ChangeCharacterFromTo(GameObject from, GameObject to, float time)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(time);

        // Deactivate the current object and activate the new object
        from.SetActive(false);
        to.SetActive(true);

        // Optional: transfer the position and rotation of the current object to the new object
        to.transform.position = from.transform.position;
        to.transform.rotation = from.transform.rotation;
    }
}
