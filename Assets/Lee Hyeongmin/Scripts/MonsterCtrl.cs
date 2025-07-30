using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Attack
    }

    public State state = State.Patrol;

    public Transform target;
    public Transform targetEyes;
    public LayerMask whatIsTarget;
    public float traceSpeed;
    public float patrolSpeed;
    public float viewDistance;
    public float viewAngle;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private bool hasTarget;
    //private bool hasSubTarget;
    private float lostTraceTime = 0;

    private float patrolDelay = 3f;
    private float patrolTimer = 4.5f;

    // ���÷���Ƽ
    private bool isMovingToCarpet = false;      // �Ҹ� ��ġ�� �̵� �� ����
    private Vector3 targetCarpetPos;            // �̵��� ī�� ��ġ
    private float carpetArriveThreshold = 0.75f; // ���� ���� �ּ� �Ÿ�

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = traceSpeed;

        animator = GetComponent<Animator>();

        hasTarget = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            state = State.Attack;
            navMeshAgent.enabled = false;
            animator.SetTrigger("Attack");

            // PlayerMovement2 ������Ʈ ��Ȱ��ȭ(������ ����)
            PlayerMovement2 pm = target.GetComponent<PlayerMovement2>();
            pm.enabled = false;

            targetEyes.LookAt(transform.position + Vector3.up * 1.5f);

            StartCoroutine(AfterAttack());
        }
    }

    private IEnumerator AfterAttack()
    {
        yield return new WaitForSeconds(1.5f);

        Vector3 playerSpawnPoint = new Vector3(-7f, 2f, 7f);
        target.position = playerSpawnPoint;
        target.rotation = Quaternion.identity;

        yield return new WaitForSeconds(0.5f);

        GameManager.Instance.PopStack();
        PlayerMovement2 pm = target.GetComponent<PlayerMovement2>();
        pm.enabled = true;
    }

    private void Update()
    {
        if (state == State.Patrol)
        {
            // Ÿ���� �ִٸ� ������ ī�� ������ �ߴ��ϰ� Ÿ�� ���� �켱
            if (hasTarget)
            {
                isMovingToCarpet = false; // �ݵ�� �Ҹ� ���� �ߴ�
                navMeshAgent.SetDestination(target.position);

                float currentDistance = Vector3.Distance(transform.position, target.position);
                if (currentDistance > viewDistance)
                {
                    lostTraceTime += Time.deltaTime;
                }
                else
                {
                    lostTraceTime = 0f;
                }
                if (lostTraceTime >= 5f)
                {
                    hasTarget = false;
                }
                return; // *** hasTarget�� �� �Ʒ� �ڵ� ���� ���� (�ſ� �߿�)
            }

            // �׻� Ÿ�� Ž��! (ī���̵� �����̵�)
            FindTarget();

            // �Ҹ� �̵�
            if (isMovingToCarpet)
            {
                navMeshAgent.SetDestination(targetCarpetPos);

                float dist = Vector3.Distance(transform.position, targetCarpetPos);
                if (dist <= carpetArriveThreshold)
                {
                    print("ī������̵���");
                    isMovingToCarpet = false;
                    RandomPatrol();
                }
                // return �ٿ��� ����
                return;
            }

            // �⺻ ����
            RandomPatrol();
        }
        else
        {

        }
    }


    public void HeardSound(Vector3 inputCarpetPos)
    {
        // �Ҹ� �̵� ���� ����
        isMovingToCarpet = true;
        //hasSubTarget = true;        // Patrol �� ���ǹ����� ���
        targetCarpetPos = inputCarpetPos;
        navMeshAgent.SetDestination(targetCarpetPos);
    }

    private void RandomPatrol()
    {
        patrolTimer += Time.deltaTime;
        if (patrolTimer > patrolDelay)
        {
            navMeshAgent.SetDestination(GetRandomPointOnNavMesh(transform.position, 10, NavMesh.AllAreas));
            patrolTimer = 0f;
        }
    }

    private void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, viewDistance, whatIsTarget);

        foreach (Collider collider in colliders)
        {
            float halfAngleInRadians = (viewAngle * 0.5f) * Mathf.Deg2Rad;

            Vector3 directionVector1 = transform.TransformDirection(Vector3.forward).normalized;
            Vector3 directionVector2 = (collider.transform.position - transform.position).normalized;
            float dotProduct = Vector3.Dot(directionVector1, directionVector2);

            if (dotProduct > Mathf.Cos(halfAngleInRadians))
            {
                Vector3 direction = (collider.transform.position - transform.position).normalized;
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (Physics.Raycast(transform.position, direction, out RaycastHit hit, distance))
                {
                    var hitLayer = hit.collider.gameObject.layer;
                    if (((1 << hitLayer) & whatIsTarget) != 0)
                    {
                        hasTarget = true;
                    }
                }
            }
        }
    }

    public Vector3 GetRandomPointOnNavMesh(Vector3 center, float distance, int areaMask)
    {
        var randomPos = Random.insideUnitSphere * distance + center;

        NavMeshHit hit;

        NavMesh.SamplePosition(randomPos, out hit, distance, areaMask);

        return hit.position;
    }

    public float gizmoRadius = 10f;
    public float gizmoDistance = 10f;
    public float angle = 80f;

    public Color gizmoColor;
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor = Color.blue;
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);

        Vector3 start = transform.position;

        float halfAngleInRadius = angle / 2 * Mathf.Deg2Rad;

        Vector3 leftDir = transform.rotation * new Vector3(-Mathf.Sin(halfAngleInRadius), 0f, Mathf.Cos(halfAngleInRadius)).normalized;
        Vector3 leftVector = start + (leftDir * gizmoDistance);
        Vector3 rightDir = transform.rotation * new Vector3(Mathf.Sin(halfAngleInRadius), 0f, Mathf.Cos(halfAngleInRadius)).normalized;
        Vector3 rightVector = start + (rightDir * gizmoDistance);

        Gizmos.color = gizmoColor = Color.red;
        Gizmos.DrawLine(start, leftVector);
        Gizmos.DrawLine(start, rightVector);
    }
}
