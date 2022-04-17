using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherSlot : MonoBehaviour
{
    public string storedObject;
    public bool isStoring = false;
    GameObject lockIcon;
    [HideInInspector]
    public bool accquiredHead = false;
    [HideInInspector]
    public bool accquiredHandle = false;
    Slot slotScript;
    GameObject hotbarSlots;

    private void Start()
    {
        lockIcon = gameObject.transform.Find("Image").gameObject;
        hotbarSlots = GameObject.Find("Slots");
    }
    public void SetCraftSlotObject(GameObject storingObject)
    {
        storedObject = storingObject.name;
        gameObject.GetComponent<Image>().color = new Color32(79, 245, 7, 255);
        isStoring = true;
        lockIcon.SetActive(false);

        if(storedObject == "Pickaxe Handle")
        {
            accquiredHandle = true;
        } else if(storedObject == "Pickaxe Head")
        {
            accquiredHead = true;
        }

        if(accquiredHandle && accquiredHead)
        {
            slotScript = hotbarSlots.transform.Find("Slot Pickaxe").gameObject.GetComponent<Slot>();
            slotScript.SetCraftedObject("Pickaxe");
        }
    }

    public void ActivateDiary()
    {
        gameObject.GetComponent<Image>().color = new Color32(255, 102, 0, 255);
        lockIcon.SetActive(false);
    }
}
