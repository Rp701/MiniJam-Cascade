using UnityEngine;

public class CarWin : MonoBehaviour
{
    GameObject Canvas;
    GameObject SceneFader;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = gameObject.transform.Find("Canvas").gameObject;
        SceneFader = GameObject.Find("SceneFader");
    }

    void OnTriggerEnter(Collider other)
    {
        if (Inventory.instance.acquiredCarKeys)
        {
            Canvas.transform.Find("PressFToWin").gameObject.SetActive(true);
        } else
        {
            Canvas.transform.Find("GetCarKey").gameObject.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Inventory.instance.acquiredCarKeys && Input.GetKeyDown(KeyCode.F))
        {
            SceneFader.GetComponent<SceneFader>().FadeTo("EndScene");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (Inventory.instance.acquiredCarKeys)
        {
            Canvas.transform.Find("PressFToWin").gameObject.SetActive(false);
        }
        else
        {
            Canvas.transform.Find("GetCarKey").gameObject.SetActive(false);
        }
    }
}
