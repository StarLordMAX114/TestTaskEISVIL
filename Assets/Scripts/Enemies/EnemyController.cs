using UnityEngine;

public sealed class EnemyController
{
    private EnemyView _enemyView;
    private PlayerView _playerView;

    private float _distance;
    
    public EnemyController(EnemyView enemyView, PlayerView playerView)
    {
        _enemyView = enemyView;
        _playerView = playerView;
        _enemyView.Agent.speed = enemyView.Speed;
    }

    public void Update()
    {
        if (_enemyView != null)
        {
            CheckDistance();
        
            if (_distance < _enemyView.RangeMovement)
            {
                StopWalk();
                Attack();
            }
            else
            {
                Pursuit();
            }
        }
    }

    private void CheckDistance()
    {
        _distance = Vector3.Distance(_playerView.transform.position , _enemyView.transform.position);
    }

    private void Attack()
    {
        
    }

    private void StopWalk()
    {
        _enemyView.Agent.SetDestination(_enemyView.transform.position);
    }

    private void Pursuit()
    {
        _enemyView.Agent.SetDestination(_playerView.transform.position);
    }
}
