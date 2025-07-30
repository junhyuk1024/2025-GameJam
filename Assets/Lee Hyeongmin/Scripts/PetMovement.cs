using UnityEngine;
using UnityEngine.AI;

public class PetMovement : MonoBehaviour
{
    public Transform target;
    public Transform startPosition;
    public float speed = 5f;
    public float stopDistance = 1.5f;
    public float rotSpeed = 1;

    private NavMeshAgent navMeshAgent;
    private GetPet getPet;

    public void Back()
    {
        transform.position = startPosition.position;
        getPet.enabled = true;
        this.enabled = false;
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
        navMeshAgent.stoppingDistance = stopDistance;

        getPet = GetComponent<GetPet>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > 10f)
        {
            transform.position = target.position;
        }

        Vector3 dir = target.position - transform.position;
        dir.y = 0f;
        
        if (dir.sqrMagnitude > 0.0001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        }
        navMeshAgent.SetDestination(target.position);
    }
}
