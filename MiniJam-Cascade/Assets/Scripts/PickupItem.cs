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
    GameObject hotbarSlots;
    Slot slotScript;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player");
        pressFText = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        inventoryScript = inventory.GetComponent<Inventory>();
        itemName = gameObject.name;
        placeHolder = GameObject.Find("HandHolder");
        hotbarSlots = GameObject.Find("Slots");
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
        

            if(itemName == "Pickaxe")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
            } 
            else if (itemName == "Sword")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
            } 
            else if (itemName == "Shovel")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
            } 
            else if (itemName == "Lighter")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
            } 
            else if (itemName == "Torch")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
            } 
            else if (itemName == "Drill")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
            } 
            else if (itemName == "Wooden Plank")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
            }


            if (placeHolder.transform.childCount != 0)
            {
                Destroy(gameObject);
            }
            else
            {
                if (gameObject.tag == "Item")
                {
                    gameObject.transform.parent = placeHolder.transform;
                    gameObject.transform.position = placeHolder.transform.position;
                    inRange = false;
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                }

                else
                {
                    Destroy(gameObject);

                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressFText.SetActive(false);
        inRange = false;
    }
}