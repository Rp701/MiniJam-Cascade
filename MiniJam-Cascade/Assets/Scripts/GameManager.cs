using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPauseMenu;
    public bool isLetterOpen;
    public static GameManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        isPauseMenu = false;
        isLetterOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
