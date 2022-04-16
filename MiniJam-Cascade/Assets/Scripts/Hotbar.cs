using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    GameObject slot;
    public GameObject slots;
    Slot slotScript;

    GameObject itemHolder;

    // Start is called before the first frame update
    void Start()
    {
        itemHolder = GameObject.Find("HandHolder").gameObject;

        slots = gameObject.transform.Find("Slots").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetItem(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetItem(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SetItem(6);
        }

        //Gets the slot for the Key and the Item in it
        void SetItem(int slotIndex)
        {
            slot = slots.transform.GetChild(slotIndex).gameObject;
            slotScript = slot.GetComponent<Slot>();
            if (slotScript.storedObject != null)
            {
                if (itemHolder.transform.childCount != 0)
                {
                    Destroy(itemHolder.transform.GetChild(0).gameObject);
                    Instantiate(slotScript.slotItemPrefab, itemHolder.transform, false);

                    itemHolder.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
                }
            }
        }

    }
}
