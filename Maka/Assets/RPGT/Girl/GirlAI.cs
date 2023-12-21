using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GirlAI : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;

    public float nextWayPointDistance = 3f;

    private Path _path;
    private int _currentWayPoint = 0;
    private bool _reachedEndOfPath = false;

    private Seeker _seeker;
    private Rigidbody2D _rb;
    private Animator _animator;
    [SerializeField] private Transform[] destinationPoints; // Ensemble de points de destination pour le NPC
    private int currentDestinationIndex = 0;
    
    
    
    void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void UpdatePath()
    {
        if(_seeker.IsDone())
            _seeker.StartPath(_rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            _path = p;
            _currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_path == null)
            return;
        if (_currentWayPoint >= _path.vectorPath.Count)
        {
            _reachedEndOfPath = true;
            return;
        }
        else
        {
            _reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)_path.vectorPath[_currentWayPoint] - _rb.position).normalized;
        Vector2 force = direction * (speed * Time.deltaTime);
        
        _rb.AddForce(force);
        _rb.MovePosition(_rb.position + direction * (speed * Time.deltaTime));
        _animator.SetFloat("Horizontal", direction.x);
        _animator.SetFloat("Vertical", direction.y);
        _animator.SetFloat("Speed", direction.sqrMagnitude);

        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            _currentWayPoint++;
        }

    }
}
