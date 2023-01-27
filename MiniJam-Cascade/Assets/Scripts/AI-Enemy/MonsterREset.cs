using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterREset : MonoBehaviour
{
    public GameObject Monster;
    public GameObject MonsterHouse;
    public bool CanReset = false;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyN2")
        {
            CanReset = true;
            StartCoroutine(MoveMonster());
        }
    }

    public IEnumerator MoveMonster()
    {
        yield return new WaitForSeconds(2);
        Monster.transform.position = MonsterHouse.transform.position;
    }
}
