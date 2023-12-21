using System.Collections;
using System.Collections.Generic;
using CodeMonkey;
using UnityEngine;

public class WaiterAI : ClientAI
{
    [SerializeField]private Transform[] tables;
    [SerializeField] private Transform chefPosition;
    public Transform[] rankTourPositions;
    [SerializeField] private Transform initialPoint;
    // Start is called before the first frame update
    private void Start()
    {
        rankTourPositions = new Transform[tables.Length + 2];
        for (int i = 0; i < tables.Length; i++)
        {
            rankTourPositions[i] = tables[i];
        }

        rankTourPositions[tables.Length] = chefPosition;
        rankTourPositions[tables.Length + 1] = initialPoint;
    }

    // Update is called once per frame

    public void MakeRankTour()
    {
        // StartCoroutine(followPathToMove(rankTourPositions));
        StartCoroutine(rankTour());
        SetDestination(initialPoint);
        // CMDebug.TextPopup("Just made a rank Tour and Collected Commands", new Vector3(18.79f,-2f,0), 2f);
        print("ROOM " + "->" + " KITCHEN" + ": CONTROLLING TABLE/TAKING COMMANDS");
    }

    private IEnumerator rankTour()
    {
        while (currentDestinationIndex < rankTourPositions.Length)
        {
       
            aiDestinationSetter.target = rankTourPositions[currentDestinationIndex];

    
            while (Vector3.Distance(transform.position, rankTourPositions[currentDestinationIndex].position) > aiPath.endReachedDistance)
            {
                yield return null;
            }


            currentDestinationIndex++;
            
            if (currentDestinationIndex >= rankTourPositions.Length)
            {
                currentDestinationIndex = 0;
                break;
            }
        }

        // Finished Moving
        
    }


}
