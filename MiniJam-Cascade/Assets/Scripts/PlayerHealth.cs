using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Stuff")]
    public float startHealth;
    private float health;
    public Image healthBar;
    public TextMeshProUGUI healthText;
    public float damageDelay = 0.5f;
    public bool takingDamage = false;

    [Header("Game Over Variables")]
    public GameObject blackFadeImage;
    public GameObject gameOverText;
    public GameObject EnemyKillYouText;
    public GameObject fellOffMapText;
    public GameObject fellInRiver;
    public GameObject redDamageImage;
    public GameObject gameOverButtons;

    private void Start()
    {
        health = startHealth;
        healthText.text = "Health: " + health.ToString();
    }

    private void Update()
    {
        //If the player's health is 0, kill the player
        if (health <= 0)
        {
            DiedToEnemy();
        }
    }

    public void DiedToEnemy()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverText.SetActive(true);
        blackFadeImage.SetActive(true);
        EnemyKillYouText.SetActive(true);
        gameOverButtons.SetActive(true);
    }

    public void FellOffMap()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverText.SetActive(true);
        blackFadeImage.SetActive(true);
        fellOffMapText.SetActive(true);
        gameOverButtons.SetActive(true);
    }

    public void FellInRiver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverText.SetActive(true);
        blackFadeImage.SetActive(true);
        fellInRiver.SetActive(true);
        gameOverButtons.SetActive(true);
    }

    public void TakingDamage()
    {
        if (takingDamage == false && health >0)
        {
            //basically don't damage the play if you're already taking damage
            StartCoroutine(EnemyHit(1));
        }
    }

    public void TakingDamageTwo()
    {
        if(takingDamage == false && health >0)
        {
            StartCoroutine(EnemyHit(4));
        }
    
    }

    private void OnTriggerStay(Collider other)
    {
        //If an enemy is attacking
        if(other.gameObject.CompareTag("Enemy"))
        {
            TakingDamage();
        }

        if(other.gameObject.CompareTag("EnemyN2"))
        {
            TakingDamageTwo();
        }

        //If the player falls out of the map
        if(other.gameObject.CompareTag("FloorKill"))
        {
            FellOffMap();
        }

        //If the palyer falls into the river
        if(other.gameObject.CompareTag("River"))
        {
            FellInRiver();
        }
    }

    IEnumerator EnemyHit(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startHealth;

        StartCoroutine(FlashHit());

        healthText.text = "Health: " + health.ToString();
        takingDamage = true;
        yield return new WaitForSeconds(damageDelay);
        takingDamage = false;
    }

    IEnumerator FlashHit()
    {
        redDamageImage.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        redDamageImage.SetActive(false);
    }
}
