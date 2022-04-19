using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("The enemy prefab that will be spawning")]
    public GameObject objectToSpawn;

    [Tooltip("The amount of time for the next enemy to spawn")]
    public float initialDelay;

    [Tooltip("The random number generated to spawn the next enemy")]
    private float spawnDelay;
    [Tooltip("The minimum amount of time for the next to spawn")]
    public float minSpawnDelay;
    [Tooltip("The maximum amount of time for the next to spawn")]
    public float maxSpawnDelay;

    private void Start()
    {
        //Go ahead and start the Spawn coroutine
        StartCoroutine(Spawn());
    }

    //the function to spawn the enemies
    IEnumerator Spawn()
    {
        while (true)
        {
            //set a random number based off our min and max to spawn the next
            spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);

            //wait the random number amount of seconds then do the next part
            yield return new WaitForSeconds(spawnDelay);

            //spawn the enemy game object at this gameobject's position
            Instantiate(objectToSpawn, transform.position, transform.rotation);

            yield return null;
        }

    }
}
