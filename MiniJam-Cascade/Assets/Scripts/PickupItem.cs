using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName;
    public GameObject inventory;
    public GameObject pressFText;
    public GameObject placeHolder;
    private bool inRange;
    Inventory inventoryScript;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player");
        pressFText = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        inventoryScript = inventory.GetComponent<Inventory>();
        itemName = gameObject.name;
        placeHolder = GameObject.Find("HandHolder");
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

            gameObject.transform.parent = placeHolder.transform;
            gameObject.transform.position = placeHolder.transform.position;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressFText.SetActive(false);
        inRange = false;
    }
}
