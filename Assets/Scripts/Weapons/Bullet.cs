using UnityEngine;

public sealed class Bullet : MonoBehaviour
{
    private PlayerView _playerView;
    private EnemyView _enemyView;
    private GameObject _bullet;
    
    private void OnTriggerEnter(Collider other)
    {
        _bullet = gameObject;
        if (other.gameObject.tag == "Player")
        {
            _playerView = other.gameObject.GetComponent<PlayerView>();
            _playerView.Health -= _enemyView.Damage;
            
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            _enemyView = other.gameObject.GetComponent<EnemyView>();
            _playerView = FindObjectOfType<PlayerView>();
            
            _enemyView.Health -= _playerView.PlayerWeapon.Damage ;
            
            Destroy(gameObject);
        }
    }
}
