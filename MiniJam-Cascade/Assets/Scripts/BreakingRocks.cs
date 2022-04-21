using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingRocks : MonoBehaviour
{
    public GameObject RockShape;

    public GameObject RockCells;

    public MeshRenderer PLS;

    public GameObject Text;

    public bool CanBreak = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "piackaxe")
        {
            Text.SetActive(true);
        }
        if(other.gameObject.tag == "piackaxe" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            PLS.enabled = false;
            RockCells.SetActive(true);
            StartCoroutine(DestroyObjects());
            CanBreak = true;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "piackaxe")
        {
            Text.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(CanBreak)
        {
            Text.SetActive(false);
        }
    }

    public IEnumerator DestroyObjects()
    {
        yield return new WaitForSeconds(5);
        Destroy(RockCells);
        Destroy(RockShape);
    }
}
