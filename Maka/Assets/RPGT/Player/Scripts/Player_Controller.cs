using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class Player_Controller : MonoBehaviour
{
    #region Editor Data

    [Header("Movement Attributes")]
    [SerializeField] float _moveSpeed = 3f;
    
    [Header("Dependencies")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Animator animator;
    #endregion
    #region Internal Data
    private Vector2 movement = Vector2.zero;

    #endregion

    #region Tick
    private void Update()
    {
        GatherInput();
    }

    private void FixedUpdate()
    {
        MovementUpdate();
    }
    #endregion

    #region Input Logic
    private void GatherInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    #endregion


    #region Movement Logic

    private void MovementUpdate()
    {
        
        // _rb.velocity = movement * _moveSpeed *Time.fixedDeltaTime;
        //print("X :" + _rb.velocity.x + " Y :" + _rb.velocity.y);
        _rb.MovePosition(_rb.position + movement * (_moveSpeed * Time.fixedDeltaTime));
    }
    #endregion
}
