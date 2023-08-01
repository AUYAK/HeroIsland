
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class HeroMotor : MonoBehaviour
{
    private float rotationSpeed = 2f;
    Transform target; //target to follow
    Transform viewTarget;// target to look at
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        if (target!=null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }   
      public void MoveToPoint(Vector3 point)
    {
        agent.updateRotation = true;
        agent.SetDestination(point);
        //      //stop once reached destination
    }
    public void FollowTarget(Interactable newTarget)
    {   
        agent.stoppingDistance = newTarget.radius *.9f;
        agent.updateRotation = false;
        target = newTarget.interactionTransform;
        viewTarget = newTarget.GetComponent<Transform>();
    }

    public void StopFollowingTarget()
    {
        agent.updateRotation = false;
        agent.stoppingDistance = 0f;
        target = null; 
    }
    void FaceTarget()
    {
        
        //Identifiing where is the point to look at in case Interactable has interaction point
        Vector3 direction = (viewTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z)); 
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime * rotationSpeed);
    }
    // IEnumerator WaitUntilReachesTarget()
    // {
    //     yield return new WaitForSeconds(0.1f);
    //     yield return new WaitUntil(() => agent.remainingDistance <= agent.stoppingDistance);
    //     agent.isStopped = true;
    //     agent.ResetPath();
    // }


}
