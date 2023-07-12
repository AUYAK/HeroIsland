using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public Camera cam;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            StartCoroutine(WaitUntilReachesTarget());
            }

        }
    }

    IEnumerator WaitUntilReachesTarget(){
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(()=>agent.remainingDistance<= agent.stoppingDistance);
        agent.isStopped = true;
        agent.ResetPath();
        

    }
}