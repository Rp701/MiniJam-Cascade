using UnityEngine;

public class Letter : MonoBehaviour
{
    public int pageNumber;
    public GameObject DiaryPages;
    public GameObject hotbar;
    GameManager gameManagerScript;

    private void Start()
    {
        //hotbar = GameObject.Find("Hotbar");
        //DiaryPages = GameObject.Find("DiaryPages");
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OpenPage()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        hotbar.SetActive(false);
        DiaryPages.transform.GetChild(pageNumber-1).gameObject.SetActive(true);
        gameManagerScript.isLetterOpen = true;
    }
    public void ClosePage()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        hotbar.SetActive(true);
        DiaryPages.transform.GetChild(pageNumber - 1).gameObject.SetActive(false);
        gameManagerScript.isLetterOpen = false;
    }
}
