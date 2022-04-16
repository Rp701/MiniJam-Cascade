using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName;
    public GameObject inventory;
    public GameObject pressFText;
    private bool inRange;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pressFText.SetActive(true);
            inRange = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inRange == true)
        {
            pressFText.SetActive(false);

            if (itemName == "Pickaxe")
            {
                inventory.GetComponent<Inventory>().pickaxeAcquired = true;
            }

            if (itemName == "Shovel")
            {
                GetComponent<Inventory>().shovelAcquired = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressFText.SetActive(false);
        inRange = false;
    }
}
