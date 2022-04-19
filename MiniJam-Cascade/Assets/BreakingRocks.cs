using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingRocks : MonoBehaviour
{
    public GameObject RockShape;

    public GameObject RockCells;

    public MeshRenderer PLS;


    // Start is called before the first frame update
    void Start()
    {
        GameObject RockShape = GameObject.Find("Rockfracturemesh");
        GameObject RockCells = GameObject.Find("RockCells2");
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "piackaxe" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            PLS.enabled = false;
            RockCells.SetActive(true);
            StartCoroutine(DestroyObjects());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DestroyObjects()
    {
        yield return new WaitForSeconds(5);
        Destroy(RockCells);
    }
}
