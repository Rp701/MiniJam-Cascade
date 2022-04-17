using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //Object stored in the Slot
    public string storedObject;
    public bool isStoring = false;
    public GameObject slotItemPrefab;
    GameObject lockIcon;

    private void Start()
    {
        gameObject.GetComponent<Image>().color = new Color32(63, 66, 64, 255);
        lockIcon = gameObject.transform.Find("Image").gameObject;
    }

    public void SetStoredObject(GameObject storingObject)
    {
        storedObject = storingObject.name;
        gameObject.GetComponent<Image>().color = new Color32(238, 238, 238, 255);
        isStoring = true;
        lockIcon.SetActive(false);
    }
}
