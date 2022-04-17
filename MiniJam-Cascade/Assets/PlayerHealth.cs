using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float HealthPlayer = 100f;
    public float CurrentHealthPlayer;

    public bool isDead = false;
    public bool HasDamaged = false;
    

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealthPlayer = HealthPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        TakeDamage();
    }

    void CheckHealth()
    {
        if(HealthPlayer <= 0f)
        {
            isDead = true;
            Dead();
        }

        if(HealthPlayer > 100f)
        {
            HealthPlayer = 100f;
            HasDamaged = false;
        }

        if(HasDamaged && HealthPlayer < 100f)
        {
            StartCoroutine(GiveBackHealth());
        }

    }

    IEnumerator GiveBackHealth()
    {
        yield return new WaitForSeconds(2);

        HealthPlayer += 5f;
    }

   void TakeDamage()
   {
       if(Input.GetKeyDown(KeyCode.T))
       {
           HealthPlayer -=10;
           HasDamaged = true;
       }
   }

    void Dead()
    {

    }
}
