using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Pathfinding;

public class CookerAI : MonoBehaviour
{
    // [SerializeField] private Transform[] patrolPoints;
    private Animator animator;
    private AIPath aiPath;
    private AIDestinationSetter aiDestinationSetter;
    [SerializeField] private Transform[] destinationPoints;
    private int currentDestinationIndex = 0;
    private float waitingTimeToPatrol = 5f;
    
    
    protected void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        aiPath = GetComponent<AIPath>();
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
    }
    IEnumerator Start()
    {
        while (true)
        {
            Patrol();
            yield return new WaitForSeconds(waitingTimeToPatrol);
        }
    }
        protected void Update()
        {
            AIMovement();
        }

        protected void AIMovement()
        {
            animator.SetFloat("Horizontal", aiPath.desiredVelocity.x);
            animator.SetFloat("Vertical", aiPath.desiredVelocity.y);
            animator.SetFloat("Speed", aiPath.desiredVelocity.sqrMagnitude);
        }

    public void Patrol()
    {
        StartCoroutine(cookerPatrol());
        // StartCoroutine(MoveToNextDestination());
    }
    
    private IEnumerator cookerPatrol()
    {
        while (currentDestinationIndex < destinationPoints.Length)
        {
       
            aiDestinationSetter.target = destinationPoints[currentDestinationIndex];
            // SetDestination(patrolPoints[currentDestinationIndex]);

    
            while (Vector3.Distance(transform.position, destinationPoints[currentDestinationIndex].position) > aiPath.endReachedDistance)
            {
                yield return null;
            }

            print("KITCHEN " + "->" + " ROOM" + ": PREPARATION - SLICING - ON FIRE");
            currentDestinationIndex++;
            
            if (currentDestinationIndex >= destinationPoints.Length)
            {
                currentDestinationIndex = 0;
                break;
            }
        }

        // Finished Moving
        print("KITCHEN " + "->" + " ROOM" + ": END OF PREPARATION");
        
    }
    
}
