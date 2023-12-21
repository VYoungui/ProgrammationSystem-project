using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey;
using UnityEngine;
using CodeMonkey.Utils;

public class chairManagement : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    
    
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //We detect a client
        if (collision.gameObject.tag == gameManager.getClientTag())
        {
            ClientAI client = collision.gameObject.GetComponent<ClientAI>();
            if (client.isSatisfied())
            {
                client.goToDestroyZone();
            }
            else
            {
                client.SetDestination(GameManager.GetAvailableChair());
                print("ROOM \" + \"->\" + \" KITCHEN\" + \": CLIENT ARRIVAL");
                // CMDebug.TextPopup("Client Just Arrived", new Vector3(18.79f,-2f,0), 1f);
            }
            
        }
        
    }


}
