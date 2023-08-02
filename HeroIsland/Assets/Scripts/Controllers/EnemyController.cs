using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    public float lookRadius = 10f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = 0;
        target = ClosestHeroInAttackRange(out distance);
        if(target != null){        
        if(distance<=lookRadius)
        {
            agent.SetDestination(target.position);
            if(distance<=agent.stoppingDistance)
            {
                //AttackTarget
                FaceTarget();
            }      
        }
        }
    }
    private void FaceTarget()
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToTarget.x,0,directionToTarget.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime *5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private Transform ClosestHeroInAttackRange(out float closestHeroDistance)
    {   
        closestHeroDistance = float.MaxValue;
        List<GameObject> heroes = HeroesManager.instance.heroes;
        float distance;
        Transform closestHero = null;
        if (heroes.Count != 0)
        {
            foreach (GameObject hero in heroes)
            {
                distance = Vector3.Distance(transform.position, hero.transform.position);
                if (distance <= lookRadius)
                {
                    closestHero = hero.transform;
                    closestHeroDistance = distance;
                }
            }
            return closestHero;
        }
        return null;
    }

}
