using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image HealthbarLine;
    public float CurrentHealth;
    public float MaxHealth = 100f;
    PlayerHealth Player;

    void Start()
    {
        //Find
        HealthbarLine = GetComponent<Image>();
        Player = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        CurrentHealth = Player.HealthPlayer;
        HealthbarLine.fillAmount = CurrentHealth / MaxHealth;
    }
}
