using UnityEngine;

public class PlacePlank : MonoBehaviour
{
    Inventory inventoryScript;
    bool isUnlocked;
    GameObject Canvas;
    GameObject HandHolder;
    GameObject currentHandItem;
    
    void Start()
    {
        inventoryScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        Canvas = gameObject.transform.Find("Canvas").gameObject;
        HandHolder = GameObject.Find("HandHolder");

    }
    void OnTriggerEnter(Collider other)
    {
        isUnlocked = inventoryScript.acquiredPlank;

        if (HandHolder.transform.childCount != 0)
        {
            currentHandItem = HandHolder.transform.GetChild(0).gameObject;

            if (other.gameObject.tag == "Player")
            {
                if (isUnlocked)
                {
                    if (currentHandItem.tag == "Plank")
                    {
                        Canvas.transform.Find("Unlocked").gameObject.SetActive(true);
                    }
                    else
                    {
                        Canvas.transform.Find("TakeItemInHand").gameObject.SetActive(true);
                    }
                }
                else
                {
                    Canvas.transform.Find("Locked").gameObject.SetActive(true);
                }
            }
        } else
            Canvas.transform.Find("Locked").gameObject.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if(HandHolder.transform.childCount != 0)
            {
                currentHandItem = HandHolder.transform.GetChild(0).gameObject;

                if (currentHandItem.tag == "Plank")
                {
                    Canvas.transform.Find("TakeItemInHand").gameObject.SetActive(false);
                    Canvas.transform.Find("Unlocked").gameObject.SetActive(true);

                    if (isUnlocked && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        gameObject.transform.Find("PlacePlank").gameObject.SetActive(true);
                        gameObject.transform.Find("PlacePlank").gameObject.transform.parent = GameObject.Find("River Planks").transform;

                        Destroy(gameObject);
                    }
                }
                else if(inventoryScript.acquiredPlank)
                {   
                    Canvas.transform.Find("Unlocked").gameObject.SetActive(false);
                    Canvas.transform.Find("TakeItemInHand").gameObject.SetActive(true);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Canvas.transform.Find("TakeItemInHand").gameObject.SetActive(false);
            Canvas.transform.Find("Unlocked").gameObject.SetActive(false);
            Canvas.transform.Find("Locked").gameObject.SetActive(false);
        }
    }
}
