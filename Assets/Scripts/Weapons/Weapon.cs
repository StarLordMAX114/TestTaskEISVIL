using System;
using UnityEngine;

public sealed class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _bulletGenerator;
    
    private Reference _reference;

    [Header("Настройки оружия")]
    
    [Tooltip("Время перезарядки")]
    [Range(0.5F,5)]public float CoolDown;
    
    [Tooltip("Скорость снаряда")]
    [Range(1,50)]public int BulletSpeed;
    
    [Tooltip("Урон")]
    [Range(1,5)] public int Damage;

    private float _currentlyCoolDown;
    [NonSerialized] public bool IsFire = true;
    
    
    private void Awake()
    {
        _reference = new Reference();
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
