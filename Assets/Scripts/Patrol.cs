using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject police;
    public Transform[] patrolPoints;

    private float moveSpeed;
    private int currentPointIndex = 0;
    private Transform currentPoint;

    private Animator animator;

    void Start()
    {
        animator = police.GetComponent<Animator>();
        currentPoint = patrolPoints[currentPointIndex];
        moveSpeed = 2f;
    }

    private void Update()
    {
        Vector3 direction = currentPoint.position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
        police.transform.LookAt(patrolPoints[currentPointIndex].position);

        if (Vector3.Distance(transform.position, patrolPoints[0].position) < 0.1f 
            || Vector3.Distance(transform.position, patrolPoints[4].position) < 0.1f)
        {
            moveSpeed = 2f;
            animator.SetBool("walk", true);
            animator.SetBool("run", false);
            animator.SetBool("idle", false);
        }
        else if (Vector3.Distance(transform.position, patrolPoints[2].position) < 0.1f 
                 || Vector3.Distance(transform.position, patrolPoints[6].position) < 0.1f)
        {
            moveSpeed = 4f;
            animator.SetBool("walk", false);
            animator.SetBool("run", true);
            animator.SetBool("idle", false);
        }
        else if (Vector3.Distance(transform.position,patrolPoints[8].position) < 0.1f)
        {
            moveSpeed = 0f;
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            animator.SetBool("idle", true);
        }

        if (Vector3.Distance(transform.position, currentPoint.position) < 0.1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= patrolPoints.Length)
            {
                currentPointIndex = 0;
            }
            currentPoint = patrolPoints[currentPointIndex];
        }
    }
}
