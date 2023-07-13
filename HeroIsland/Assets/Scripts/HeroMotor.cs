
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class HeroMotor : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
        //      //stop once reached destination
        // StartCoroutine(WaitUntilReachesTarget());
    }
    // IEnumerator WaitUntilReachesTarget()
    // {
    //     yield return new WaitForSeconds(0.1f);
    //     yield return new WaitUntil(() => agent.remainingDistance <= agent.stoppingDistance);
    //     agent.isStopped = true;
    //     agent.ResetPath();
    // }
}
