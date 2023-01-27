using UnityEngine;

public class Hotbar : MonoBehaviour
{
    GameObject slot;
    public GameObject mainSlots;
    public GameObject otherSlots;
    Slot slotScript;
    public static Hotbar instance;
    public static GameObject hotbar;

    public GameObject itemHolder;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        hotbar = gameObject;
        itemHolder = GameObject.Find("HandHolder").gameObject;

        mainSlots = gameObject.transform.Find("Slots").gameObject;
        otherSlots = gameObject.transform.Find("Other Slots").gameObject;
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
    }
    //Gets the slot for the Item and activates it
    public void SetItem(int slotIndex)
    {
        slot = mainSlots.transform.GetChild(slotIndex).gameObject;
        slotScript = slot.GetComponent<Slot>();

        if (!string.IsNullOrEmpty(slotScript.storedObject))
        {
            if(itemHolder.transform.childCount != 0)
            {
                Destroy(itemHolder.transform.GetChild(0).gameObject);
            }

            Instantiate(slotScript.slotItemPrefab, itemHolder.transform, false);
        }
    }
}
