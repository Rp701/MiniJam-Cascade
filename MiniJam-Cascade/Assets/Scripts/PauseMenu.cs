using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    bool isCanvasActive;

    GameObject mouseSensitivityField;
    Text currentMouseSens;

    GameObject notValidMouseSens;
    float validMouseSens;

    //float f is used for checking mouseSens
    private float floatOut;

    MouseLook mouseLook;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = gameObject.transform.Find("PauseMenu").gameObject;
        mouseSensitivityField = pauseMenu.transform.Find("MouseSensitivity").gameObject;
        notValidMouseSens = mouseSensitivityField.transform.Find("NotValidMouseSens").gameObject;
        isCanvasActive = false;
        pauseMenu.SetActive(false);
        /*mouseLook = GameObject.Find("FirstPersonPlayer").gameObject.transform.Find("MainCamera").gameObject.GetComponent<MouseLook>();
        currentMouseSens = mouseSensitivitySlider.transform.Find("CurrentMouseSens").gameObject.GetComponent<Text>();
        currentMouseSens.text = mouseLook.mouseSensitivity.ToString();*/

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isCanvasActive)
            {
                pauseMenu.SetActive(true);
                isCanvasActive = true;
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            } else
            {
                pauseMenu.SetActive(false);
                isCanvasActive = false;
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }    
        }
    }
    /*public void checkForValidFloat(string mouseSensitivityString)
    {
        bool isFloat = float.TryParse(mouseSensitivityString, out float floatOut);

        Debug.Log(isFloat);

        if (float.TryParse(mouseSensitivityString, out floatOut))
        {
            Debug.Log("String is the number: " + floatOut);
        } else
        {
            Debug.Log("Not valid float");
        }

        if ()
        {
            Debug.Log("validFloat");
            if (float.Parse(mouseSensitivityString) < 0)
            {
                notValidMouseSens.SetActive(true);
            } else
            {
                changeMouseSens(mouseSensitivityString);
                notValidMouseSens.SetActive(false);
                Debug.Log(mouseLook.mouseSensitivity);
            }
        } else
        {
            notValidMouseSens.SetActive(true);
        } 

    }
    void changeMouseSens(string mouseSensitivityString)
    {
        mouseLook.mouseSensitivity = float.Parse(mouseSensitivityString);
    }
    */

}
