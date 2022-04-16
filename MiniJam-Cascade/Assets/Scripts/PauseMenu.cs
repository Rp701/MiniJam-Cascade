using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    bool isCanvasActive;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = gameObject.transform.Find("PauseMenu").gameObject;
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
}
