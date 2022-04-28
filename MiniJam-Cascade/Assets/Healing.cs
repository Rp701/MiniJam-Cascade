using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public PlayerHealth Heal;
    public GameObject MaxHealthText;
    public GameObject LowHealthText;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Heal.CanGetHeal == false)
        {
            MaxHealthText.SetActive(true);
        }

        if(other.gameObject.tag == "Player" && Heal.CanGetHeal == true)
        {
            LowHealthText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                Heal.HealingOne();
                Destroy(gameObject);
                MaxHealthText.SetActive(false);
                LowHealthText.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            MaxHealthText.SetActive(false);
            LowHealthText.SetActive(false);
        }
    }
}
