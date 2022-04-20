using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherSlot : MonoBehaviour
{
    public string storedObject;
    public bool isStoring = false;
    GameObject lockIcon;
    Slot slotScript;
    GameObject hotbarSlots;
    Inventory inventoryScript;

    private void Start()
    {
        inventoryScript = GameObject.Find("FirstPersonPlayer").GetComponent<Inventory>();
        lockIcon = gameObject.transform.Find("Image").gameObject;
        hotbarSlots = GameObject.Find("Slots");
    }
    public void SetCraftSlotObject(GameObject storingObject)
    {
        storedObject = storingObject.name;
        gameObject.GetComponent<Image>().color = new Color32(79, 245, 7, 255);
        isStoring = true;
        lockIcon.SetActive(false);
        if(storedObject == "Car Key")
        {
            Debug.Log("Picked Up Car Key");
        }else if(storedObject == "Pickaxe Handle")
        {
            inventoryScript.acquiredHandle = true;
        } else if(storedObject == "Pickaxe Head")
        {
            inventoryScript.acquiredHead = true;
        }

        if(inventoryScript.acquiredHandle && inventoryScript.acquiredHead)
        {
            slotScript = hotbarSlots.transform.Find("Slot Pickaxe").gameObject.GetComponent<Slot>();
            slotScript.SetCraftedObject("Pickaxe");
        }
    }
}
