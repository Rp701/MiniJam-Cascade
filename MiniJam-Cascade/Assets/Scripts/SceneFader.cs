using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
        Debug.Log("Fading to " + scene);
    }
    public void FadeToIndex(int index)
    {
        StartCoroutine(FadeOutIndex(index));
    }
    public void QuitGame(string scene)
    {
        StartCoroutine(FadeOut(scene));
        Application.Quit();
        Debug.Log("Quit");
    }
    IEnumerator FadeIn()
    {
        Time.timeScale = 1f;

        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }
    IEnumerator FadeOut(string scene)
    {
        Time.timeScale = 1f;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        
        SceneManager.LoadScene(scene);
    }
    IEnumerator FadeOutIndex(int index)
    {
        Time.timeScale = 1f;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        SceneManager.LoadScene(index);
    }
}
