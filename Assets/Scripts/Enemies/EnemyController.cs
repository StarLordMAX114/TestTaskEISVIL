using UnityEngine;

public sealed class EnemyController
{
    private EnemyView _enemyView;
    private PlayerView _playerView;

    private float _distance;
    private float _currentTimeImmobility;
    private float _currentRangeMovement;
    private int _currentPlayerHealth;
    private bool _isRangeMovementUP;
    private bool _canWalk = true;

    public EnemyController(EnemyView enemyView, PlayerView playerView)
    {
        _enemyView = enemyView;
        _playerView = playerView;

        _enemyView.Agent.speed = enemyView.Speed;
        _currentTimeImmobility = _enemyView.TimeImmobility;
    }

    public void Update()
    {
        Debug.Log(_currentTimeImmobility);
        if (_enemyView != null)
        {
            CheckDistance();
        
            if (_distance <= _enemyView.RangeMovement & _distance > _enemyView.AttackDistance & _canWalk)
            {
                _currentTimeImmobility = _enemyView.TimeImmobility;
                Pursuit();
            }
            else if (_distance <= _enemyView.AttackDistance)
            {
                Attack(_playerView);
                StopWalk();
            }
            if(_canWalk == false & _currentTimeImmobility != _enemyView.TimeImmobility)
            {
                _currentTimeImmobility -= Time.deltaTime;
                if (_currentTimeImmobility <= 0)
                {
                    _canWalk = true;
                    _currentTimeImmobility = _enemyView.TimeImmobility;
                }
            }

            if (_currentPlayerHealth <= _playerView.Health / 2 & _isRangeMovementUP)
            {
                _enemyView.RangeMovement = _currentRangeMovement * 2;
                _isRangeMovementUP = false;
            }
        }
    }
    private void StopWalk()
    {
        _canWalk = false;
        _enemyView.Agent.SetDestination(_enemyView.transform.position);
        if(_currentTimeImmobility != 0)
        {
            _currentTimeImmobility -= Time.deltaTime;
            if (_currentTimeImmobility <= 0)
            {
                _canWalk = true;
            }
        }
    }

    private void Attack(PlayerView _playerView)
    {
        _enemyView.transform.LookAt(_playerView.transform.position);
        _enemyView.EnemyWeapon.Fire();
    }

    private void CheckDistance()
    {
        _distance = Vector3.Distance(_playerView.transform.position , _enemyView.transform.position);
    }
    
    private void Pursuit()
    {
        _enemyView.Agent.SetDestination(_playerView.transform.position);
    }
}
