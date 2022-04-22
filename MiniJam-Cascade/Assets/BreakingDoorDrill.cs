using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingDoorDrill : MonoBehaviour
{
        public GameObject DoorShape;

    public GameObject DoorCells;

    public MeshRenderer PLS;

    public GameObject Text;

    public bool CanBreak = false;

    public bool openOtherDoor = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Drill")
        {
            Text.SetActive(true);
        }
        if(other.gameObject.tag == "Drill" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            PLS.enabled = false;
            DoorCells.SetActive(true);
            StartCoroutine(DestroyObjects());
            CanBreak = true;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Drill")
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
        Destroy(DoorCells);
        Destroy(DoorShape);
        openOtherDoor = true;
    }
}
