using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused;
    public bool isLetterOpen;
    // Start is called before the first frame update
    void Start()
    {
        isGamePaused = false;
        isLetterOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
