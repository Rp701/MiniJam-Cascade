using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;

    public float minTime;
    public float maxTime;

    private void Update()
    {
        if(isFlickering == false)
        {
            StartCoroutine(FlickerControl());
        }
    }

    IEnumerator FlickerControl()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
