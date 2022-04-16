using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterSeconds : MonoBehaviour
{
    public GameObject objectToDisable;
    public float timeUntilDisable;
    private float resetTime;
    bool itemNeedsReset;
    private void Start()
    {
        resetTime = timeUntilDisable;

        if (itemNeedsReset == true)
        {
            timeUntilDisable = resetTime;
        }
        StartCoroutine(startTimer());
    }

    IEnumerator startTimer()
    {
        //wait x amount of seconds then disable the object
        yield return new WaitForSeconds(resetTime);
        objectToDisable.SetActive(false);
    }
}
