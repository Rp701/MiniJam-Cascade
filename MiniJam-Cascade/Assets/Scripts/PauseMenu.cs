using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    bool isCanvasActive;

    // Start is called before the first frame update
    void Start()
    {
        isCanvasActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isCanvasActive)
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
                isCanvasActive = true;
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            } else
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
                isCanvasActive = false;
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }    
        }
    }
}
