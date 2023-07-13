
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class HeroMotor : MonoBehaviour
{
    private float rotationSpeed = 5f;
    Transform target; //target to follow
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
        agent.SetDestination(point);
        //      //stop once reached destination
        // StartCoroutine(WaitUntilReachesTarget());
    }
    public void FollowTarget(Interactable newTarget)
    {   
        agent.stoppingDistance = newTarget.radius *.9f;
        agent.updateRotation = false;
        target = newTarget.transform;
    }

    public void StopFollowingTarget()
    {
        agent.updateRotation = false;
        agent.stoppingDistance = 0f;
        target = null; 
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
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
