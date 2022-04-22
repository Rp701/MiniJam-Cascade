using UnityEngine;

public class CarWin : MonoBehaviour
{
    Inventory inventoryScript;
    GameObject Canvas;
    GameObject SceneFader;

    // Start is called before the first frame update
    void Start()
    {
        inventoryScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        Canvas = gameObject.transform.Find("Canvas").gameObject;
        SceneFader = GameObject.Find("SceneFader");
    }

    void OnTriggerEnter(Collider other)
    {
        if (inventoryScript.acquiredCarKeys)
        {
            Canvas.transform.Find("PressFToWin").gameObject.SetActive(true);
        } else
        {
            Canvas.transform.Find("GetCarKey").gameObject.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (inventoryScript.acquiredCarKeys && Input.GetKeyDown(KeyCode.F))
        {
            SceneFader.GetComponent<SceneFader>().FadeTo("EndScene");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (inventoryScript.acquiredCarKeys)
        {
            Canvas.transform.Find("PressFToWin").gameObject.SetActive(false);
        }
        else
        {
            Canvas.transform.Find("GetCarKey").gameObject.SetActive(false);
        }
    }
}
