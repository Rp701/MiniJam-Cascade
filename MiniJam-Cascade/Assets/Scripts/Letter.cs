using UnityEngine;

public class Letter : MonoBehaviour
{
    public int pageNumber;
    GameObject DiaryPages;
    GameObject hotbar;

    private void Start()
    {
        hotbar = GameObject.Find("Hotbar");
        DiaryPages = GameObject.Find("DiaryPages");
    }

    public void OpenPage()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        hotbar.SetActive(false);
        DiaryPages.transform.GetChild(pageNumber-1).gameObject.SetActive(true);
        GameObject.Find("GameManager").GetComponent<GameManager>().isGamePaused = true;
    }
    public void ClosePage()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        hotbar.SetActive(true);
        DiaryPages.transform.GetChild(pageNumber - 1).gameObject.SetActive(false);
        GameObject.Find("GameManager").GetComponent<GameManager>().isGamePaused = false;
    }
}
