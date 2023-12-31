using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroAnimator : MonoBehaviour
{
    const float locomotionSmoothTime = 0.1f;
    Animator animator;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {     
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent",speedPercent,locomotionSmoothTime,Time.deltaTime);       
    }
}
