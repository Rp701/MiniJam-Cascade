using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float EnemyHealthHeart = 20f;

    public bool isDead = false;
    

    public float dyingSmooth = 2.5f;
    public float RotationOfDeath = 0f;
    public float GeneralDeathRotation;
    


    // Start is called before the first frame update
    void Start()
    {
        RotationOfDeath = GeneralDeathRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sword")
        {
            EnemyHealthHeart -= 5f;
            Debug.Log(EnemyHealthHeart);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "sword" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            EnemyHealthHeart -= 5f;
            Debug.Log(EnemyHealthHeart);
        }
    }

    void Die()
    {
        float DeathRotationTwo = -90f;
        if(EnemyHealthHeart <= 0f)
        {
            RotationOfDeath = DeathRotationTwo;
            gameObject.transform.Rotate(GeneralDeathRotation, 0f, 0f);
            isDead = true;
            Destroy(gameObject, 2.5f);
        }
        GeneralDeathRotation = Mathf.Lerp(GeneralDeathRotation, RotationOfDeath, Time.deltaTime * dyingSmooth);
    }
}
