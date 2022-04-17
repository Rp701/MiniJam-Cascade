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
    private bool inRange;
    Inventory inventoryScript;
    GameObject hotbarSlots;
    Slot slotScript;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player");
        pressFText = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        pressFToLoot = GameObject.Find("Canvas").transform.Find("PressFToLoot").gameObject;
        inventoryScript = inventory.GetComponent<Inventory>();
        itemName = gameObject.name;
        placeHolder = GameObject.Find("HandHolder");
        hotbarSlots = GameObject.Find("Slots");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag != "DeadBody")
        {
            if (other.gameObject.tag == "Player")
            {
                pressFText.SetActive(true);
                inRange = true;
            }
        } else
        {
            pressFToLoot.SetActive(true);
            inRange = true;
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inRange == true)
        {
            if (pressFToLoot.activeInHierarchy)
            {
                pressFToLoot.SetActive(false);

            } else if(pressFText.activeInHierarchy)
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
                            slotScript.slotItemPrefab.GetComponent<BoxCollider>().enabled = false;

                            Destroy(placeHolder.transform.GetChild(0).gameObject);

                            Instantiate(slotScript.slotItemPrefab, placeHolder.transform, false);

                            Destroy(gameObject);

                    }
                    else
                    {
                        slotScript.slotItemPrefab.GetComponent<BoxCollider>().enabled = false;

                        Instantiate(slotScript.slotItemPrefab, placeHolder.transform, false);

                        Destroy(gameObject);

                    }
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