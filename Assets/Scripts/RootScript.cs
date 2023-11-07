using System.Collections.Generic;
using UnityEngine;

public sealed class RootScript : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private List<EnemyView> _enemyViews;

    private PlayerController _playerController;
    private EnemyManager _enemyManager;
    private PlayerManager _playerManager;
    private EventManager _eventManager;
    
    private void Awake()
    {
        _playerController = new PlayerController(_playerView);

        _eventManager = new EventManager();
        _enemyManager = new EnemyManager(_enemyViews, _playerView, _eventManager );
        _playerManager = new PlayerManager(_playerView, _enemyViews);
    }

    private void Update()
    {
        _playerController.Update();
        _enemyManager.Update();
        _playerManager.Update();
    }
    //Пропиши TriggerEnter и допиши ивенты, что бы спавнились монетки
}
