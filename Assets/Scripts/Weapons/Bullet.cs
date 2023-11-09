using UnityEngine;

public sealed class Bullet : MonoBehaviour
{
    private PlayerView _playerView;
    private EnemyView _enemyView;
    private float _timer = 1F;

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerView = other.gameObject.GetComponent<PlayerView>();
            _enemyView = FindObjectOfType<EnemyView>();
            
            _playerView.Health -= _enemyView.EnemyWeapon.Damage;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            _enemyView = other.gameObject.GetComponent<EnemyView>();
            _playerView = FindObjectOfType<PlayerView>();
            
            _enemyView.Health -= _playerView.PlayerWeapon.Damage ;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }
    }
}
