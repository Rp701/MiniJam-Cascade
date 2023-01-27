using UnityEngine;

public class Letter : MonoBehaviour
{
    private GameObject DiaryPages;
    private GameObject hotbar;
    [SerializeField] private int pageNumber;

    private void Awake()
    {
        DiaryPages = GameObject.Find("DiaryPages");
    }
    public void OpenPage()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        Hotbar.hotbar.SetActive(false);
        DiaryPages.transform.GetChild(pageNumber - 1).gameObject.SetActive(true);
        GameManager.instance.isLetterOpen = true;
    }
    public void ClosePage()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        Hotbar.hotbar.SetActive(true);
        DiaryPages.transform.GetChild(pageNumber - 1).gameObject.SetActive(false);
        GameManager.instance.isLetterOpen = false;
    }
}
