using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName;
    public GameObject inventory;
    public GameObject pressFText;
    public GameObject pressFToLoot;
    public GameObject placeHolder;
    public GameObject inventoryCanvas;
    private bool inRange;
    Inventory inventoryScript;
    GameObject hotbarSlots;
    int slotAmount;
    Slot slotScript;

    private void Start()
    {
        inventoryCanvas = GameObject.Find("InventoryCanvas");
        inventory = GameObject.FindGameObjectWithTag("Player");
        pressFText = inventoryCanvas.transform.Find("PressFText").gameObject;
        pressFToLoot = inventoryCanvas.transform.Find("PressFToLoot").gameObject;
        inventoryScript = inventory.GetComponent<Inventory>();
        itemName = gameObject.name;
        placeHolder = GameObject.Find("HandHolder");
        hotbarSlots = GameObject.Find("Slots");
        slotAmount = hotbarSlots.transform.childCount;

        for (int i = 0; i < slotAmount; i++)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Player")
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

            inRange = false;


            if (itemName == "Pickaxe")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
                Debug.Log("Pickaxe");
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
                Debug.Log("Drill");
            }
            else if (itemName == "Wooden Plank")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
            }

            if(slotScript.slotItemPrefab != null)
            {
                if (placeHolder.transform.childCount != 0)
                {

                            Destroy(placeHolder.transform.GetChild(0).gameObject);

                            Instantiate(slotScript.slotItemPrefab, placeHolder.transform, false);

                            Destroy(gameObject);

                            placeHolder.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = false;

                }
                else
                {
                    Instantiate(slotScript.slotItemPrefab, placeHolder.transform, false);

                    Destroy(gameObject);

                    placeHolder.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = false;

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