using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class WteAi : MonoBehaviour
{
    private Animator animator;
    private AIPath aiPath;
    private AIDestinationSetter aiDestinationSetter;
    [SerializeField]private Transform entryPoint;
    [SerializeField]private Transform foodTable;
    [SerializeField] private Transform[] destinationPoints;
    private int currentDestinationIndex = 0;
    [SerializeField] private float waitingTimeToServe = 10f;
    private Transform currentClientToServe;

    private GameManager gameManager;
    // Start is called before the first frame update
    protected void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        aiPath = GetComponent<AIPath>();
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
    }
    // ReSharper disable Unity.PerformanceAnalysis
    // ReSharper disable Unity.PerformanceAnalysis
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        // destinationPoints = new Transform[4];
        destinationPoints = new Transform[3];
        // destinationPoints[0] = entryPoint;
        // destinationPoints[1] = foodTable;
        // destinationPoints[3] = entryPoint;
        destinationPoints[0] = foodTable;
        destinationPoints[2] = entryPoint;

        FunctionPeriodic.Create(() =>
        {
            if (CheckIfClientsExist())
            {
                currentClientToServe = GetRandomClient().transform;
                // destinationPoints[2] = currentClientToServe;
                destinationPoints[1] = currentClientToServe;
                StartCoroutine(serveClient());
            }

        }, waitingTimeToServe);
        // while (CheckIfClientsExist())
        // {
        //     yield return new WaitForSeconds(waitingTimeToServe);
        //     currentClientToServe = GetRandomClient().transform;
        //     destinationPoints[2] = currentClientToServe;
        //     StartCoroutine(serveClient());
        // }   
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
    
    private IEnumerator serveClient()
    {
        while (currentDestinationIndex < destinationPoints.Length)
        {
       
            aiDestinationSetter.target = destinationPoints[currentDestinationIndex];
            // SetDestination(patrolPoints[currentDestinationIndex]);

    
            while (Vector3.Distance(transform.position, destinationPoints[currentDestinationIndex].position) > aiPath.endReachedDistance)
            {
                yield return null;
            }

            print("KITCHEN " + "->" + " ROOM" + ": PLATE PREPARATION");
            currentDestinationIndex++;
            
            if (currentDestinationIndex >= destinationPoints.Length)
            {
                currentDestinationIndex = 0;
                break;
            }
        }

        // Finished Moving
        print("ROOM " + "->" + " KITCHEN" + ": CLIENT SERVED");
        
    }
    private bool CheckIfClientsExist()
    {
        GameObject[] clientObjects = GameObject.FindGameObjectsWithTag("Client");
        return clientObjects.Length > 0;
    }
    private GameObject GetRandomClient()
    {
        GameObject[] clientObjects = GameObject.FindGameObjectsWithTag("Client");
            // int randomIndex = Random.Range(0, clientObjects.Length);
            return clientObjects[0];

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == gameManager.getClientTag())
        {
            ClientAI client = collision.gameObject.GetComponent<ClientAI>();
            client.SetSatisfaction(true);
            if (client.transform == currentClientToServe && client.isSatisfied())
            {
                client.goToDestroyZone();
            }
            
        }
    }
}
