using UnityEngine;
using TMPro;

public class PickupItem : MonoBehaviour
{
    string itemName;
    public bool inRange;
    GameObject inventory;
    Inventory inventoryScript;
    GameObject pressFText;
    GameObject placeHolder;
    GameObject TorchHolder;
    GameObject inventoryCanvas;
    GameObject hotbarSlots;
    GameObject otherSlots;
    Slot slotScript;
    Letter letterScript;
    private string originialPressF;
    OtherSlot otherSlotScript;
    int pageNumber;

    private void Awake()
    {
        inventoryCanvas = GameObject.Find("InventoryCanvas");
        inventory = GameObject.FindGameObjectWithTag("Player");
        inventoryScript = inventory.GetComponent<Inventory>(); 
        pressFText = inventoryCanvas.transform.Find("PressFText").gameObject;
        itemName = gameObject.name;
        originialPressF = pressFText.GetComponent<TMP_Text>().text;

        TorchHolder = GameObject.Find("TorchHolder");
        placeHolder = GameObject.Find("HandHolder");
        hotbarSlots = GameObject.Find("Slots");
        otherSlots = GameObject.Find("Other Slots");
        if(gameObject.tag == "Letter")
        {
            letterScript = gameObject.GetComponent<Letter>();
            pageNumber = letterScript.pageNumber;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Letter")
            {
                pressFText.GetComponent<TMP_Text>().text = "Press F to read page " + pageNumber.ToString();
                pressFText.SetActive(true);
                inRange = true;
            } else if (gameObject.tag == "Car Key") 
            {
                pressFText.GetComponent<TMP_Text>().text = "Press F to pick up the Car Key";
                pressFText.SetActive(true);
                inRange = true;
            }
            else
            {
                pressFText.GetComponent<TMP_Text>().text = originialPressF + itemName;
                pressFText.SetActive(true);
                inRange = true;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inRange == true)
        {
            pressFText.SetActive(false);

            inRange = false;

            if (itemName == "Sword")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
                Debug.Log("Sword");
            }
            else if (itemName == "Shovel")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
                inventoryScript.acquiredShovel = true;
            }
            else if (itemName == "Torch")
            {
                slotScript = TorchHolder.GetComponent<Slot>();
                
                Instantiate(slotScript.slotItemPrefab, TorchHolder.transform, false);

                Destroy(gameObject);
            }
            else if (itemName == "Drill")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
            }
            else if (itemName == "Plank")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
                inventoryScript.acquiredPlank = true;
            }
            else if (itemName == "Pickaxe Head")
            {
                otherSlotScript = otherSlots.transform.Find(itemName).gameObject.GetComponent<OtherSlot>();
                otherSlotScript.SetCraftSlotObject(gameObject);
                inventoryScript.acquiredHead = true;
            }
            else if (itemName == "Pickaxe Handle")
            {
                otherSlotScript = otherSlots.transform.Find(itemName).gameObject.GetComponent<OtherSlot>();
                otherSlotScript.SetCraftSlotObject(gameObject);
                inventoryScript.acquiredHandle = true;
            } else if(gameObject.tag == "Car Key")
            {
                otherSlotScript = otherSlots.transform.Find("Car Key").gameObject.GetComponent<OtherSlot>();
                otherSlotScript.SetCraftSlotObject(gameObject);
                inventoryScript.acquiredCarKeys = true;
            }
            else if (gameObject.tag == "Letter")
            {
                letterScript.OpenPage();
            }

            if (gameObject.tag == "Item")
            {
                if (slotScript.slotItemPrefab != null)
                {
                    if (placeHolder.transform.childCount != 0)
                    {
                        Destroy(placeHolder.transform.GetChild(0).gameObject);
                    }

                    Instantiate(slotScript.slotItemPrefab, placeHolder.transform, false);

                    Destroy(gameObject);
                } 
            } else if(gameObject.tag != "Letter")
            {
                Destroy(gameObject);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressFText.SetActive(false);
        inRange = false;
    }
}