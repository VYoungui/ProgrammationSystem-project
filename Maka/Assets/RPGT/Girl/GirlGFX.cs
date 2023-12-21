using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GirlGFX : MonoBehaviour
{

    public AIPath aiPath;
    private Animator animator;
    // Update is called once per frame


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        animator.SetFloat("Horizontal", aiPath.desiredVelocity.x);
        animator.SetFloat("Vertical", aiPath.desiredVelocity.y);
        animator.SetFloat("Speed", aiPath.desiredVelocity.sqrMagnitude);
    }
}
