using UnityEngine;
using UnityEngine.UI;

#region require components
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
#endregion


[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    public EnemyDetails enemyDetails;
    Image _healthBar; 
    float _currentHealth;    
    WayPoint _waypoints;    
    LevelManager _levelManager;    
    int _passedPoints = 0;    
    Vector3 _nextLocation;     
    public bool visible = true;
    [HideInInspector] public float MoveSpeed;
    private SimpleFlash _simpleFlash;

    void Start()
    {
        //Pegando informa��es b�sicas
        _currentHealth = enemyDetails.maxHealth;
             
        MoveSpeed = enemyDetails.moveSpeed;        
        _waypoints = FindObjectOfType<WayPoint>();
        _levelManager = FindObjectOfType<LevelManager>();         
        _healthBar = GetComponentInChildren<Image>();
        _simpleFlash = GetComponent<SimpleFlash>();

        _nextLocation = _waypoints.Points[_passedPoints];
    }   

    void Update()
    {
        Move();
        //Rotate();

        //if (CurrentPointPositionReached())
        //    UpdateCurrentPointIndex();
    }

    //Gerenciando movimenta��o
    #region Movement
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
    //void Rotate()
    //{
    //    if (CurrentPointPosition.x > _lastPointPosition.x)
    //        _spriteRenderer.flipX = false;
    //    else
    //        _spriteRenderer.flipX = true;
    //}
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
        ResetHealthBar();
        ObjectPooler.RetunToPool(gameObject);

        _levelManager.ReduceLives();
        _levelManager.EnemyConcluded();

        if(enemyDetails.name == "Phishing")
        {
            _levelManager.LoseMoney(100);
        }else if(enemyDetails.name == "RamsomWare")
        {
            _levelManager.GameOver();
        }
    }
    #endregion

    //Gerenciando a vida do inimigo
    #region EnemyHP
    public void TakeDamage(float damageReceived)
    {
        _simpleFlash.Flash();
        _currentHealth -= damageReceived;
        if (_currentHealth <= 0)
        {
            Die();
        }
        else
        {
            _healthBar.fillAmount = (_currentHealth / enemyDetails.maxHealth);
        }
    }

     public void ResetHealthBar()
    {
        _currentHealth = enemyDetails.maxHealth;
        _healthBar.fillAmount = 1;
    }

    public void Die()
    {
        _passedPoints = 0;
        _nextLocation = _waypoints.Points[0];
        ResetHealthBar();
        _levelManager.GetMoney(enemyDetails.moneyDrop);
        _levelManager.EnemyConcluded();
        ObjectPooler.RetunToPool(gameObject);        
    }

  #endregion
}
