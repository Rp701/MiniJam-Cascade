using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMonster2 : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public Transform homeMonster;
    public float Distance;
    public float AttackDistance;
    public float ChaseDistance;

    public GameObject Monster;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
                Debug.Log("Attacking");
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


    void GetReferences()
    {

    }
}
