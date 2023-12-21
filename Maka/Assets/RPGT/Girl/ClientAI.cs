using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class ClientAI : MonoBehaviour
{

    protected AIPath aiPath;

    // [SerializeField] private Transform target;

     protected Animator animator;
     protected AIDestinationSetter aiDestinationSetter;
     protected Transform transform;
     [SerializeField] protected Transform[] destinationPoints; // Ensemble de points de destination pour le NPC
     protected int currentDestinationIndex = 0;
     [SerializeField] private GameObject entryPoint;
     [SerializeField] private GameObject destroyPoint;
     protected Transform currentDestination;

     private bool satisfied = false;
     // [SerializeField] private GameObject exitPoint;
    
     protected void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        aiPath = GetComponent<AIPath>();
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
    }

    private void Start()
    {
        SetDestination(entryPoint.transform);
    }


    // Update is called once per frame
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

    public void SetDestination(Transform destination)
    {
        if (destination == null)
        {
            aiPath.destination = entryPoint.transform.position;
            SetCurrentDestination(entryPoint.transform);
        }
        else
        {
            SetCurrentDestination(destination);
            aiPath.destination = destination.position;
        }
    }

    protected void MoveTo(Vector3 position)
    {
        aiDestinationSetter.target.position = position;
    }
     protected IEnumerator MoveToNextDestination()
    {
        while (currentDestinationIndex < destinationPoints.Length)
        {
            // Définir la nouvelle destination pour le NPC
            // aiPath.destination = destinationPoints[currentDestinationIndex].position;
            aiDestinationSetter.target = destinationPoints[currentDestinationIndex];

            // Attendre que le NPC atteigne la destination actuelle
            while (Vector3.Distance(transform.position, destinationPoints[currentDestinationIndex].position) > aiPath.endReachedDistance)
            {
                yield return null;
            }

            // Changer de destination
            currentDestinationIndex++;

            // Vérifier si toutes les destinations ont été atteintes
            if (currentDestinationIndex >= destinationPoints.Length)
            {
                // Toutes les destinations ont été atteintes, terminer le déplacement
                currentDestinationIndex = 0;
                break;
            }
        }

        // Le déplacement est terminé
        print("Déplacement terminé.");
    }

    public void goToDestroyZone()
    {
        SetDestination(destroyPoint.transform);
    }

    private void followPathToMove()
    {
        StartCoroutine(MoveToNextDestination());
    }

    protected IEnumerator followPathToMove(Transform[] pathToDestination)
    {
        while (currentDestinationIndex < pathToDestination.Length)
        {
            // Définir la nouvelle destination pour le NPC
            // aiPath.destination = destinationPoints[currentDestinationIndex].position;
            aiDestinationSetter.target = pathToDestination[currentDestinationIndex];

            // Attendre que le NPC atteigne la destination actuelle
            while (Vector3.Distance(transform.position, pathToDestination[currentDestinationIndex].position) > aiPath.endReachedDistance)
            {
                yield return null;
            }

            // Changer de destination
            currentDestinationIndex++;

            // Vérifier si toutes les destinations ont été atteintes
            if (currentDestinationIndex >= pathToDestination.Length)
            {
                // Toutes les destinations ont été atteintes, terminer le déplacement
                currentDestinationIndex = 0;
                break;
            }
        }

        
    }
    
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     
    //     print("collision with : " + collision.name);
    // }

    public bool isSatisfied()
    {
        return satisfied;
    }
    public void SetSatisfaction(Boolean _satisfied)
    {
        satisfied = _satisfied;
    }

    public void SetCurrentDestination(Transform destination)
    {
        currentDestination = destination;
    }
    public Transform GetCurrentDestination()
    {
        return currentDestination;
    }

    
}
