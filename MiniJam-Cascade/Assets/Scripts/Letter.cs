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
        Time.timeScale = 0f;
        hotbar.SetActive(false);
        DiaryPages.transform.GetChild(pageNumber-1).gameObject.SetActive(true);
        Debug.Log(DiaryPages);
    }
    public void ClosePage()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        hotbar.SetActive(true);
        DiaryPages.transform.GetChild(pageNumber - 1).gameObject.SetActive(false);
    }
}
