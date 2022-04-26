using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMonster3 : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public Transform homeMonster;
    public float Distance;
    public float AttackDistance;
    public float ChaseDistance;
    public bool Attack;
    


    public GameObject Monster;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("FirstPersonPlayer");
        target = Player.transform;
        homeMonster = GameObject.FindGameObjectWithTag("HomeMonster").transform;
        InvokeRepeating ("ChangeSpeed", 5.0f, 7.5f);

    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Monster.transform.position, Player.transform.position);
        MoveToTarget();
        MoveToHome();
    }

    void MoveToTarget()
    {
        if(Distance < ChaseDistance)
        {
            agent.SetDestination(target.position);
            if(Distance <= AttackDistance)
            {
                //Attacking
                Attack = true;
                Debug.Log("Attacking");
            }
            if(Attack && Distance > AttackDistance)
            {
                Attack = false;
                Debug.Log("NotAttackingMore");
            }
        }
        
    }

    void MoveToHome()
    {
        if(Distance > ChaseDistance)
        {
            agent.SetDestination(homeMonster.position);

        }
    }

    void ChangeSpeed()
    {
        GetComponent<NavMeshAgent>().speed = Random.Range(39.6f, 50.4f);
    }




    void GetReferences()
    {

    }
}
