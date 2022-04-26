using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    bool isCanvasActive;
    bool isGamePaused;
    // Start is called before the first frame update
    void Start()
    {
        isCanvasActive = false;
        isGamePaused = GameObject.Find("GameManager").GetComponent<GameManager>().isGamePaused;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameObject.Find("GameManager").GetComponent<GameManager>().isGamePaused == false)
            {
                if (isCanvasActive == false)
                {
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        gameObject.transform.GetChild(i).gameObject.SetActive(true);
                    }
                    isCanvasActive = true;
                    Time.timeScale = 0f;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        gameObject.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    isCanvasActive = false;
                    if (isGamePaused)
                    {
                    }
                    Time.timeScale = 1f;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }  
        }
    }
}
