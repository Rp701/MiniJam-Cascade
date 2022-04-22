using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawner : MonoBehaviour
{
    public GameObject Spawner;
    public bool CanThenStop = false;

    // Start is called before the first frame update
    void Start()
    {
        Spawner.SetActive(false);
        StartCoroutine(StartSpawner());
    }

    // Update is called once per frame
    

    public IEnumerator StartSpawner()
    {
        yield return new WaitForSeconds(5);
        Spawner.SetActive(true);
        CanThenStop = true;
        StartCoroutine(CanStopSapwning());
    }

    public IEnumerator CanStopSapwning()
    {
        yield return new WaitForSeconds(10);
        Spawner.SetActive(false);
        CanThenStop = false;
    }
}
