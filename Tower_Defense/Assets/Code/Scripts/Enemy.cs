using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MoveSpeed;    
    [SerializeField] EnemyHP EnemyHp;    
    WayPoint _waypoints;    
    LevelManager _levelManager;    

    int _passedPoints = 0;
    
    Vector3 _nextLocation;   

    void Start()
    {
        //Pegando informações básicas
        _waypoints = FindObjectOfType<WayPoint>();
        _levelManager = FindObjectOfType<LevelManager>(); 
        

        _nextLocation = _waypoints.Points[_passedPoints];
    }   

    void Update()
    {
        Move();
        //Rotate();

        //if (CurrentPointPositionReached())
        //    UpdateCurrentPointIndex();
    }

    private void Move()
    {
        if(transform.position == _nextLocation)
        {
            _passedPoints++;
            if(_waypoints.Points.Length == _passedPoints)            
                EndPointReached();            
            else            
                _nextLocation = _waypoints.Points[_passedPoints];            
        }
        transform.position = Vector3.MoveTowards(transform.position, _nextLocation, MoveSpeed * Time.deltaTime);
                
    }

    //bool CurrentPointPositionReached()
    //{
    //    float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;
    //    if (distanceToNextPointPosition < 0.1f)
    //    {
    //        _lastPointPosition = transform.position;
    //        return true;
    //    }
    //    return false;
    //}

    //void UpdateCurrentPointIndex()
    //{
    //    int lastWaypointIndex = WayPoint.Points.Length - 1;
    //    if (_currentWaypointIndex < lastWaypointIndex)
    //        _currentWaypointIndex++;
    //    else
    //        EndPointReached();
    //}

    public void EndPointReached()
    {
        _passedPoints = 0;
        _nextLocation = _waypoints.Points[0];
        EnemyHp.ResetHealthBar();
        ObjectPooler.RetunToPool(gameObject);

        _levelManager.ReduceLives();
    }

    public void Die()
    {
        _passedPoints = 0;
        _nextLocation = _waypoints.Points[0];
        EnemyHp.ResetHealthBar();
        ObjectPooler.RetunToPool(gameObject);        
    }

    //void Rotate()
    //{
    //    if (CurrentPointPosition.x > _lastPointPosition.x)
    //        _spriteRenderer.flipX = false;
    //    else
    //        _spriteRenderer.flipX = true;
    //}
}
