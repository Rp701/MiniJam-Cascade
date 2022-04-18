using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health Variables")]
    public float playerHealth;
    public TextMeshProUGUI healthText;
    public GameObject blackFadeImage;
    public GameObject gameOverText;
    public GameObject EnemyKillYouText;
    public GameObject fellOffMapText;
    public GameObject fellInRiver;
    public GameObject redDamageImage;

    public bool takingDamage = false;
    public float damageDelay = 0.75f;

    private void Start()
    {
        blackFadeImage = GameObject.Find("BlackFadeImage");
        gameOverText = GameObject.Find("GameOver Text");
        EnemyKillYouText = GameObject.Find("EnemyKilledYou - Text");
        fellOffMapText = GameObject.Find("FellOffMap - Text");
        fellInRiver = GameObject.Find("FellInRiver - Text");
    }

    private void Update()
    {
        //If the player's health is 0, kill the player
        if (playerHealth <= 0)
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
    }

    public void FellOffMap()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverText.SetActive(true);
        blackFadeImage.SetActive(true);
        fellOffMapText.SetActive(true);
    }

    public void FellInRiver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverText.SetActive(true);
        blackFadeImage.SetActive(true);
        fellOffMapText.SetActive(true);
    }

    public void TakingDamage()
    {
        if (takingDamage == false && playerHealth >0)
        {
            //basically don't damage the play if you're already taking damage
            StartCoroutine(EnemyHit());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            TakingDamage();
        }
    }

    IEnumerator EnemyHit()
    {
        playerHealth -= 1;

        StartCoroutine(FlashHit());

        healthText.text = "Health: " + playerHealth.ToString();
        takingDamage = true;
        yield return new WaitForSeconds(damageDelay);
        takingDamage = false;
    }

    IEnumerator FlashHit()
    {
        redDamageImage.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        redDamageImage.SetActive(false);
    }
}
