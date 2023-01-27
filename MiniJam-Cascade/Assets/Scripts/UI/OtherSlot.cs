using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherSlot : MonoBehaviour
{
    public string storedObject;
    public bool isStoring = false;
    private GameObject hotbarSlots;
    GameObject lockIcon;
    Slot slotScript;
    Inventory inventoryScript;

    private void Start()
    {
        inventoryScript = Inventory.instance;
        lockIcon = gameObject.transform.Find("Image").gameObject;
        hotbarSlots = Hotbar.hotbar;
    }
    public void SetCraftSlotObject(GameObject storingObject)
    {
        storedObject = storingObject.name;
        gameObject.GetComponent<Image>().color = new Color32(79, 245, 7, 255);
        isStoring = true;
        lockIcon.SetActive(false);
        if(storedObject == "Pickaxe Handle")
        {
            if (inventoryScript.acquiredHandle && inventoryScript.acquiredHead)
            {
                slotScript = hotbarSlots.transform.Find("Slot Pickaxe").gameObject.GetComponent<Slot>();
                slotScript.SetCraftedObject("Pickaxe");
            }
        } else if(storedObject == "Pickaxe Head")
        {
            if (inventoryScript.acquiredHandle && inventoryScript.acquiredHead)
            {
                slotScript = hotbarSlots.transform.Find("Slot Pickaxe").gameObject.GetComponent<Slot>();
                slotScript.SetCraftedObject("Pickaxe");
            }
        }
    }
}
