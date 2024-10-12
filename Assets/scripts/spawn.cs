using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference; // Array to hold different monster prefabs
    [SerializeField]
    private Transform leftPos;   // Reference to left spawn position (you can add rightPos if needed)
    private GameObject spawnmon;
    private int ranindex;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnmons());
    }

    IEnumerator spawnmons()
    {
        while (true)
        {
            // Wait for a random time between 1 and 5 seconds before spawning the next monster
            yield return new WaitForSeconds(Random.Range(1, 5));

            // Randomly choose a monster prefab from the array
            ranindex = Random.Range(0, monsterReference.Length);
            spawnmon = Instantiate(monsterReference[ranindex]);

            // Set the spawn position to the left position
            spawnmon.transform.position = leftPos.position;

            // Assign a random speed for the spawned monster to move to the right
            spawnmon.GetComponent<rocks>().speed = Random.Range(4, 10);
        }
    }
}
