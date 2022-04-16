using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName;
    public GameObject inventory;
    public GameObject pressFText;
    private bool inRange;
    Inventory inventoryScript;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player");
        pressFText = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        inventoryScript = inventory.GetComponent<Inventory>();
        itemName = gameObject.name;
    }

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

            if (itemName == "Pickaxe Handle")
            {
                inventoryScript.pickaxeHandleAcquired = true;

                if (inventoryScript.pickaxeheadAcquired)
                {
                    Debug.Log("You can craft the pickaxe");
                }
            }

            if (itemName == "Shovel")
            {
                GetComponent<Inventory>().shovelAcquired = true;
            }

            Debug.Log(gameObject.name);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressFText.SetActive(false);
        inRange = false;
    }
}
