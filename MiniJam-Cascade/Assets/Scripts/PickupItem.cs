using UnityEngine;
using TMPro;

public class PickupItem : MonoBehaviour
{
    public string itemName;
    public GameObject inventory;
    public GameObject pressFText;
    public GameObject placeHolder;
    public GameObject inventoryCanvas;
    public bool inRange;
    GameObject hotbarSlots;
    GameObject otherSlots;
    Slot slotScript;
    public int pageNumber;
    string originialPressF;
    OtherSlot otherSlotScript;

    private void Start()
    {
        inventoryCanvas = GameObject.Find("InventoryCanvas");
        inventory = GameObject.FindGameObjectWithTag("Player");
        pressFText = inventoryCanvas.transform.Find("PressFText").gameObject;
        itemName = gameObject.name;
        originialPressF = pressFText.GetComponent<TMP_Text>().text;
        
        placeHolder = GameObject.Find("HandHolderLighter");
        hotbarSlots = GameObject.Find("Slots");
        otherSlots = GameObject.Find("Other Slots");
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Player")
            {
            pressFText.GetComponent<TMP_Text>().text = originialPressF + itemName;
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

            if (itemName == "Sword")
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
            else if (itemName == "Plank")
            {
                slotScript = hotbarSlots.transform.Find("Slot " + itemName).gameObject.GetComponent<Slot>();
                slotScript.SetStoredObject(gameObject);
            }
            else if (itemName == "Pickaxe Head")
            {
                otherSlotScript = otherSlots.transform.Find(itemName).gameObject.GetComponent<OtherSlot>();
                otherSlotScript.SetCraftSlotObject(gameObject);
            }
            else if (itemName == "Pickaxe Handle")
            {
                otherSlotScript = otherSlots.transform.Find(itemName).gameObject.GetComponent<OtherSlot>();
                otherSlotScript.SetCraftSlotObject(gameObject);
            }
            else if (itemName == "Letter")
            {
                slotScript = otherSlots.transform.Find("Diary").gameObject.GetComponent<Slot>();
                if (otherSlots.transform.Find("Diary").gameObject.transform.childCount == 0)
                {
                    otherSlotScript.ActivateDiary();
                }
            }

            if (gameObject.tag == "Item")
            {
                if (slotScript.slotItemPrefab != null)
                {
                    if (placeHolder.transform.childCount != 0)
                    {

                        Destroy(placeHolder.transform.GetChild(0).gameObject);
                        Debug.Log("Destroyed in Hand");

                    }

                    Instantiate(slotScript.slotItemPrefab, placeHolder.transform, false);

                    placeHolder.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = false;

                    Destroy(gameObject);
                } 
            } else
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