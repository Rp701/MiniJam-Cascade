using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    bool isCanvasActive;

    public Text mouseSensitivity;

    MouseLook mouseLook;

    // Start is called before the first frame update
    void Start()
    {
        isCanvasActive = false;
        pauseMenu.SetActive(false);
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
            }
            else
            {
                pauseMenu.SetActive(false);
                isCanvasActive = false;
            }    
        }
    }

    public void updateMouseSensitivity()
    {
        Debug.Log("WOW");
    }
}
