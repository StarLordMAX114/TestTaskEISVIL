using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class PlayerManager : MonoBehaviour
{
    private PlayerView _playerView;
    private EnemyView _enemyView;
    
    public PlayerManager(PlayerView playerView)
    {
        _playerView = playerView;
    }

    public void Update()
    {
        CheckPlayerHealth();
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
}
