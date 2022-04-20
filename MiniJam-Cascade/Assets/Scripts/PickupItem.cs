using UnityEngine;
using TMPro;

public class PickupItem : MonoBehaviour
{
    public string itemName;
    public GameObject inventory;
    GameObject pressFText;
    GameObject placeHolder;
    GameObject inventoryCanvas;
    GameObject DiaryPages;
    public bool inRange;
    GameObject hotbarSlots;
    GameObject otherSlots;
    Slot slotScript;
    string originialPressF;
    OtherSlot otherSlotScript;
    public int pageNumber;
    private string pageName;

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
        DiaryPages = inventoryCanvas.transform.Find("DiaryPages").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Player")
            {
                if (gameObject.tag== "Letter") 
                {
                    pressFText.GetComponent<TMP_Text>().text = "Read Page " + pageNumber.ToString();
                    pressFText.SetActive(true);
                    inRange = true;
                } else
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
            } else if(itemName == "Car Key")
            {
                otherSlotScript = otherSlots.transform.Find(itemName).gameObject.GetComponent<OtherSlot>();
                otherSlotScript.SetCraftSlotObject(gameObject);
            }
            else if (gameObject.tag == "Letter")
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                inventoryCanvas.transform.Find("Hotbar").gameObject.SetActive(false);
                pageName = "Page " + pageNumber.ToString();
                Debug.Log(DiaryPages);
                DiaryPages.SetActive(true);
                DiaryPages.transform.Find(pageName).gameObject.SetActive(true);
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

                    placeHolder.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = false;

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