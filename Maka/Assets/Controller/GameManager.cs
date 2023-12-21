using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject clientPrefab;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<Transform> chairPositions;
    private static Dictionary<Transform, bool> chairStatus;
    [SerializeField]private WaiterAI wp1;
    [SerializeField]private WaiterAI wp2;
    [SerializeField]private CookerAI ck1;
    [SerializeField]private CookerAI ck2;
    [SerializeField]private WaiterAI wp3;
    [SerializeField]private WaiterAI wp4;
    [SerializeField] private float waitingTimeToCommand = 5f;
    [SerializeField] private float waitingTimeToPatrol = 5f;

    public int maxClients = 10;
    public float timeBetweenClient = 5f;
    private int currentClientCount = 0;

    private String clientTag = "Client";

    private String chairTag = "Chair";

    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        GameObject[] chairObjects = GameObject.FindGameObjectsWithTag(chairTag);
        chairStatus = new Dictionary<Transform, bool>();
        foreach (GameObject chairObject in chairObjects)
        {
            chairPositions.Add(chairObject.transform);
        }
        foreach (Transform chair in chairPositions)
        {
            chairStatus.Add(chair,false);
        }
        StartCoroutine(InstantiateClientPeriodically());



        while (CheckIfClientsExist())
        {
            WaitersRanksTours();
            yield return new WaitForSeconds(waitingTimeToCommand);
        }
    }

    public static Transform GetAvailableChair()
    {
        List<Transform> availableChairs = new List<Transform>();
        foreach (var kvp in chairStatus)
        {
            if (!kvp.Value)
            {
                availableChairs.Add(kvp.Key);
            }
        }

        if (availableChairs.Count > 0)
        {
            int randomIndex = Random.Range(0, availableChairs.Count);
            setChairStatus(availableChairs[randomIndex],true);
            return availableChairs[randomIndex];
        }

        return null;
    }

    private IEnumerator InstantiateClientPeriodically()
    {
        while (currentClientCount < maxClients)
        {
            // Instancier le client à la position spécifiée
            Instantiate(clientPrefab, spawnPoint.position, Quaternion.identity);

            // Augmenter le nombre de clients instanciés
            currentClientCount++;

            // Attendre 5 secondes
            yield return new WaitForSeconds(timeBetweenClient);
        }
        
    }

    private static void setChairStatus(Transform chair, bool status)
    {
        if (chairStatus.ContainsKey((chair)))
        {
            chairStatus[chair] = status;
        }
        else
        {
            print("The specified chair does not exists");
        }
    }


    public String getClientTag()
    {
        return this.clientTag;
    }

    private void WaitersRanksTours()
    {
        wp1.MakeRankTour();
        wp2.MakeRankTour();
    }
    private void CookerPatrols()
    {
        ck1.Patrol();
        ck2.Patrol();
    }
    private bool CheckIfClientsExist()
    {
        GameObject[] clientObjects = GameObject.FindGameObjectsWithTag("Client");
        return clientObjects.Length > 0;
    }
}
