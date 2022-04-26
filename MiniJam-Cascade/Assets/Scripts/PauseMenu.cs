using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    bool isCanvasActive;
    GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        isCanvasActive = false;
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isCanvasActive == false)
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
                isCanvasActive = true;
                if(gameManagerScript.isLetterOpen == false)
                {
                    Time.timeScale = 0f;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                gameManagerScript.isPauseMenu = true;
            }
            else
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
                isCanvasActive = false;
                if (gameManagerScript.isLetterOpen == false)
                {
                    Time.timeScale = 1f;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                gameManagerScript.isPauseMenu = false;
                
            }
        }
    }
}
