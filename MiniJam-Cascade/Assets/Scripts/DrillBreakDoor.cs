using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillBreakDoor : MonoBehaviour
{
    public GameObject DoorShape;

    public GameObject DoorCells;

    public MeshRenderer PLS;

    public Collider ObjectCollider;

    public GameObject Text;

    public GameObject TextTwo;

    public float DrillingTimes;

    public float MaxDrillingTimes = 2f;

    public bool CanBreak = false;

    public bool CanBreakDoor = false;


    // Start is called before the first frame update
    void Start()
    {
        ObjectCollider = GetComponent<Collider>();
        DrillingTimes = 0;
    }


    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Drill")
        {
            Text.SetActive(true);
        }
        if(other.gameObject.tag == "Drill" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            DrillingTimes += 1f;
        }
        if(other.gameObject.tag == "Drill" && CanBreakDoor)
        {
            PLS.enabled = false;
            DoorCells.SetActive(true);
            StartCoroutine(DestroyObjects());
            CanBreak = true;
            ObjectCollider.isTrigger = true;
            
        }
        if(other.gameObject.tag == "piackaxe")
        {
            TextTwo.SetActive(true);
        }
        if(other.gameObject.tag == "sword")
        {
            TextTwo.SetActive(true);
        }
        if(other.gameObject.tag == "Plank")
        {
            TextTwo.SetActive(true);
        }
        if(other.gameObject.tag == "Shovel")
        {
            TextTwo.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Drill")
        {
            Text.SetActive(false);
        }
        if(other.gameObject.tag == "piackaxe")
        {
            TextTwo.SetActive(false);
        }
        if(other.gameObject.tag == "sword")
        {
            TextTwo.SetActive(false);
        }
        if(other.gameObject.tag == "Plank")
        {
            TextTwo.SetActive(false);
        }
        if(other.gameObject.tag == "Shovel")
        {
            TextTwo.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(CanBreak)
        {
            Text.SetActive(false);
        }

        if(DrillingTimes >= MaxDrillingTimes)
        {
            DrillingTimes = MaxDrillingTimes;
            CanBreakDoor = true;
        }
    }

    public IEnumerator DestroyObjects()
    {
        yield return new WaitForSeconds(5);
        Destroy(DoorCells);
        Destroy(DoorShape);
    }
}
