using UnityEngine;
using TMPro;

public class PickupItem : MonoBehaviour
{
    public bool inRange;
    public GameObject pressFText;
    public GameObject handHolder;
    public GameObject TorchHolder;
    public GameObject inventoryCanvas;
    public GameObject hotbarSlots;
    public GameObject otherSlots;
    [SerializeField] private string actionDescription = "Pick up the ";
    Slot slotScript;
    Letter letterScript;
    OtherSlot otherSlotScript;

    private void Start()
    {
        inventoryCanvas = GameObject.Find("InventoryCanvas");
        pressFText = inventoryCanvas.transform.Find("PressFText").gameObject;

        //TorchHolder = GameObject.Find("TorchHolder");
        //handHolder = GameObject.Find("HandHolder");
        //hotbarSlots = GameObject.Find("Slots");
        otherSlots = GameObject.Find("Other Slots");
        if (gameObject.tag == "Letter")
        {
            letterScript = gameObject.GetComponent<Letter>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            pressFText.GetComponent<TMP_Text>().text = "Press F to " + actionDescription + gameObject.name;
            pressFText.SetActive(true);
            inRange = true;
        }
    }

    private void Update()
    {
        PickUp(Inventory.instance);
    }

    private void PickUp(Inventory inventory)
    {
        string itemName = gameObject.name;
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
                inventory.acquiredShovel = true;
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
                inventory.acquiredPlank = true;
            }
            else if (itemName == "Pickaxe Head")
            {
                inventory.acquiredHead = true;
                otherSlotScript = otherSlots.transform.Find(itemName).gameObject.GetComponent<OtherSlot>();
                otherSlotScript.SetCraftSlotObject(gameObject);
            }
            else if (itemName == "Pickaxe Handle")
            {
                inventory.acquiredHandle = true;
                otherSlotScript = otherSlots.transform.Find(itemName).gameObject.GetComponent<OtherSlot>();
                otherSlotScript.SetCraftSlotObject(gameObject);
            }
            else if (gameObject.tag == "Car Key")
            {
                inventory.acquiredCarKeys = true;
                otherSlotScript = otherSlots.transform.Find("Car Key").gameObject.GetComponent<OtherSlot>();
                otherSlotScript.SetCraftSlotObject(gameObject);
            }
            else if (gameObject.tag == "Letter")
            {
                letterScript.OpenPage();
            }

            if (gameObject.tag == "Item")
            {
                if (slotScript.slotItemPrefab != null)
                {
                    if (handHolder.transform.childCount != 0)
                    {
                        Destroy(handHolder.transform.GetChild(0).gameObject);
                    }

                    Instantiate(slotScript.slotItemPrefab, handHolder.transform, false);

                    Destroy(gameObject);
                }
            }
            else if (gameObject.tag != "Letter")
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