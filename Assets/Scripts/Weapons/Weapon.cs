using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _bulletGenerator;
    
    private Reference _reference;
    private PlayerView _playerView;
    
    [Header("Настройки оружия")]
    
    [Tooltip("Время перезарядки")]
    [Range(1,5)]public float CoolDown;
    
    [Tooltip("Скорость снаряда")]
    [Range(1,100)]public int BulletSpeed = 100;
    
    [Tooltip("Урон")]
    [Range(1,5)] public int Damage;

    private float _currentlyCoolDown;
    public bool IsFire = true;
    
    
    private void Awake()
    {
        _reference = new Reference();
        _playerView = FindObjectOfType<PlayerView>();
        _currentlyCoolDown = CoolDown;
    }
    
    public void Fire()
    {
        if (IsFire)
        {
            _currentlyCoolDown -= Time.deltaTime;
            if (_currentlyCoolDown <= 0)
            {
                IsFire = false;
                
                 Rigidbody bullet = Instantiate(_reference.Bullet, _bulletGenerator.position, _bulletGenerator.rotation);
                 bullet.AddForce(_bulletGenerator.transform.forward * BulletSpeed, ForceMode.Impulse);
            }

        }
        else if (IsFire == false)
        {
            _currentlyCoolDown = CoolDown;
            IsFire = true;
        }
    }
    
}
