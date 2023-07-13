using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{

    public Camera cam;
    private NavMeshAgent agent;

    public Interactable focus;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //movements
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

            agent.SetDestination(hit.point);
            StartCoroutine(WaitUntilReachesTarget());
            //remove focus from interactable object
            RemoveFocus();
            }

        }
        //interactions
        if(Input.GetMouseButtonDown(0))
        {   
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null )
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    IEnumerator WaitUntilReachesTarget(){
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(()=>agent.remainingDistance<= agent.stoppingDistance);
        agent.isStopped = true;
        agent.ResetPath();
    }
    void SetFocus(Interactable newfocus)
    {
        focus = newfocus;
    }
    void RemoveFocus ()
    {
        focus = null;
    }
}