using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class PlayerManager
{
    private PlayerView _playerView;
    private EnemyView _enemyView;
    
    private List<EnemyView> _enemyViews;
    private List<float> _distances; // Дистанции до каждого противника

    private Reference _reference;
    

    public PlayerManager(PlayerView playerView, List<EnemyView> enemyViews)
    {
        EventManager.onEnemyDeath += KillEnemy;
        _playerView = playerView;
        _enemyViews = enemyViews;
        
        _distances = new List<float>();
    }

    public void Update()
    {
        if (_playerView.PlayerRigidbody.velocity == Vector3.zero)
        {
            AutoGuidance();
        }
        else
        {
            RefreshDistances();
        }
        
        CheckPlayerHealth();
    }

    private void KillEnemy()
    {
        _reference = new Reference();
    }

    #region Получение урона и смерть

    private void CheckPlayerHealth()
    {
        if (_playerView.Health <= 0)
        {
            Death();
        }
    }
    
    private void Death()
    {
        SceneManager.LoadScene(0);  
    }
    

    #endregion

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

                if (distance == _distances.Min())
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
