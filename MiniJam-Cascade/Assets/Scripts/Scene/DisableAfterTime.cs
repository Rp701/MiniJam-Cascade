using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    public GameObject itemToDisable;
    public float timer = 0.02f;
    private float startTimer;
    public bool resetTimer = false;

    private void Start()
    {
        startTimer = timer;
        itemToDisable = gameObject;
        StartCoroutine(StartTimer());

        if(resetTimer == true)
        {
            //reset the timer so it can dissapear
            timer = startTimer;
        }
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timer);
        itemToDisable.SetActive(false);
    }
}
