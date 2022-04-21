using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxForUIText : MonoBehaviour
{
    public GameObject Text;

    public BreakingRocks PLST;

    void Start()
    {

    }

    void OnTriggerStay(Collider other)
    {
        Text.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        Text.SetActive(false);
    }

    void Update()
    {
        if(PLST.CanBreak)
        {
            Destroy(Text);
        }
    }

}
