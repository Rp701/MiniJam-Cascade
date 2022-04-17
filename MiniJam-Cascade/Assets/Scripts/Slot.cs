using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //Object stored in the Slot
    public string storedObject;
    public int itemAmount;
    public bool isStoring = false;
    public GameObject slotItemPrefab;

    private void Start()
    {
        gameObject.GetComponent<Image>().color = new Color32(63, 66, 64, 255);
    }

    public void SetStoredObject(GameObject storingObject)
    {
        storedObject = storingObject.name;
        gameObject.GetComponent<Image>().color = new Color32(238, 238, 238, 255);
        isStoring = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
