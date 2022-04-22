using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawner : MonoBehaviour
{
    public GameObject Spawner;
    public bool CanThenStop = false;

    void Awake()
    {
        Spawner = GameObject.Find("Sphere");
        Spawner.GetComponent<EnemySpawner>().enabled = false;
        StartCoroutine(StartSpawner());
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    

    public IEnumerator StartSpawner()
    {
        yield return new WaitForSeconds(5);
        Spawner.GetComponent<EnemySpawner>().enabled = true;
        CanThenStop = true;
        Debug.Log("StartSpawn");
        StartCoroutine(CanStopSapwning());
    }

    public IEnumerator CanStopSapwning()
    {
        yield return new WaitForSeconds(30);
        Destroy(Spawner);
        Debug.Log("StopSpawn");
        CanThenStop = false;
    }
}
