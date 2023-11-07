using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class EnemyManager : MonoBehaviour
{
    private List<EnemyView> _enemyViews;
    private List<EnemyController> _enemyControllers;
    
    private EnemyView _enemyView;
    private EnemyController _enemyController;
    
    private PlayerView _playerView;
    private EventManager _eventManager;
    public EnemyManager(List<EnemyView> enemyViews, PlayerView playerView , EventManager eventManager)
    {
        _enemyViews = enemyViews;
        _playerView = playerView;
        _eventManager = eventManager;
        
        _enemyControllers = new List<EnemyController>();
        RefreshEnemyList();
    }
    
    public void Update()
    {
        foreach (EnemyController enemyController in _enemyControllers)
        {
            enemyController.Update();
        }
        CheckEnemiesHealh();
    }

    private void CheckEnemiesHealh()
    {
        foreach (EnemyView _enemyView in _enemyViews.ToList())
        {
            if (_enemyView.Health <= 0)
            {
                _enemyViews.Remove(_enemyView);
                Death(_enemyView);
            }
        }
    }

    private void Death(EnemyView enemyView)
    {
        _eventManager.EnemyDeath();;
        Destroy(enemyView.gameObject);
    }
    
    private void RefreshEnemyList()
    {
        foreach (EnemyView _enemyView in _enemyViews)
        {
            if (_enemyView != null)
            {
                _enemyController = new EnemyController(_enemyView, _playerView);
                _enemyControllers.Add(_enemyController);
            }
        }
    }
}
