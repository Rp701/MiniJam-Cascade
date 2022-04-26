using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelDigSpot : MonoBehaviour
{
    Inventory inventoryScript;
    bool isUnlocked;
    GameObject Canvas;
    GameObject HandHolder;
    GameObject currentHandItem;
    private GameObject DropItem;
    public GameObject DropPrefab;
    public Vector3 Dig;

    void Start()
    {
        inventoryScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        Canvas = gameObject.transform.Find("Canvas").gameObject;
        HandHolder = GameObject.Find("HandHolder");

    }
    void OnTriggerEnter(Collider other)
    {
        isUnlocked = inventoryScript.acquiredShovel;

        if (HandHolder.transform.childCount != 0)
        {
            currentHandItem = HandHolder.transform.GetChild(0).gameObject;

            if (other.gameObject.tag == "Player")
            {
                if (isUnlocked)
                {
                    if (currentHandItem.tag == "Shovel")
                    {
                        Canvas.transform.Find("Dig").gameObject.SetActive(true);
                    }
                    else
                    {
                        Canvas.transform.Find("GetShovel").gameObject.SetActive(true);
                    }
                }
                else
                {
                    Canvas.transform.Find("FindShovel").gameObject.SetActive(true);
                }
            }
        }
        else
        {
                Canvas.transform.Find("FindShovel").gameObject.SetActive(true);
        }

    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (HandHolder.transform.childCount != 0)
            {
                currentHandItem = HandHolder.transform.GetChild(0).gameObject;

                if (currentHandItem.tag == "Shovel")
                {
                    if (isUnlocked && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("Digged");
                        DropItem = Instantiate(DropPrefab, Dig, Quaternion.identity);
                        DropItem.name = "Car Key";
                        DropItem.transform.parent = null;

                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Canvas.transform.Find("GetShovel").gameObject.SetActive(false);

            if (isUnlocked)
            {
                Canvas.transform.Find("Dig").gameObject.SetActive(false);
            }
            else
            {
                Canvas.transform.Find("FindShovel").gameObject.SetActive(false);
            }
        }
    }
}
