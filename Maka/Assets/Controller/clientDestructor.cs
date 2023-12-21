using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class clientDestructor : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == gameManager.getClientTag())
        {
            Destroy(collision.gameObject);
            print("A Client is gone");
        }
    }
}
