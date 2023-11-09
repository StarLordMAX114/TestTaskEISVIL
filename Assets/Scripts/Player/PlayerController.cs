using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class PlayerController
{
    private PlayerView _playerView;
    private Rigidbody _rigidbody;
    private FixedJoystick _joystick;
    
    private List<EnemyView> _enemyViews;
    private List<float> _distances; // Дистанции до каждого противника
    
    public PlayerController(PlayerView playerView, List<EnemyView> enemyViews)
    {
        _playerView = playerView;
        _enemyViews = enemyViews;
        
        _distances = new List<float>();
        
        _rigidbody = _playerView.PlayerRigidbody;
        _joystick = _playerView.Joystick;
    }

    public void Update()
    {
        Move();
        if (_playerView.PlayerRigidbody.velocity == Vector3.zero)
        {
            AutoGuidance();
        }
        
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _playerView.Speed, _rigidbody.velocity.y, _joystick.Vertical * _playerView.Speed);
        if (_playerView.Joystick.Horizontal != 0 || _playerView.Joystick.Vertical != 0)
        {
            _playerView.transform.rotation = Quaternion.LookRotation(_playerView.PlayerRigidbody.velocity);
        }
    }
    #region Автонаводка и атака

    private void RefreshDistances()
    {
        _distances.Clear();
    }
    
    private void AutoGuidance()
    {
        RefreshDistances();
        
        foreach (EnemyView _enemyView in _enemyViews)
        {
            if (_enemyView != null)
            {
                float distance = Vector3.Distance(_playerView.transform.position,_enemyView.transform.position);
                _distances.Add(distance);

                if (distance == _distances.Min() & distance <= _playerView.AttackDistance)
                {
                    Attack(_enemyView);
                }
            }
        }
    }

    private void Attack(EnemyView enemyView)
    {
        _playerView.transform.LookAt(enemyView.transform.position);
        _playerView.PlayerWeapon.Fire();
    }
    #endregion
}
